
# Sistema de Tickets para Problemas de Internet - Processo seletivo Claro

##  🚀 Funcionalidades

- **Dashboard Personalizado** - Visão geral de tickets e métricas relevantes.
- **Gerenciamento de Tickets** - Criação, visualização.
- **Histórico de Tickets** - Registro completo de todos tickets gerados.
- **Métricas de Negócio** - Indicadores de desempenho e estatísticas de atendimento
- **Observabilidade** - Integração com Dynatrace e Splunk para monitoramento
- **Design Responsivo** - Interface adaptável para desktop e dispositivos móveis

## Tech

Tecnologias e ferramentas usadas no projeto:

- [C#] - Linguagem robusta e moderna para backend
- [CSS] - Linguagem de estilo que define a aparência visual de páginas web de alta eficiência e fácil manutenção.
- [Cshtml] - Extensão de arquivo usada em aplicações ASP.NET permitindo a geração dinâmica de conteúdo no servidor com C#
- [Ipify] -Ipify é uma API simples e poderosa que permite obter o endereço IP público
- [Dynatrace] - Plataforma avançada de observabilidade e monitoramento de performance de aplicações
- [Splunk] - Plataforma poderosa de análise de dados e observabilidade
- [PowerBI] - Plataforma de análise de dados e visualização interativa permite transformar dados brutos em relatórios dinâmicos e dashboards acessíveis.
- [SQLServer] - É um sistema de gerenciamento de banco de dados relacional
## Requisitos basicos
- Docker
 
## Instalação

abra o caminho do programa baixado no terminal
Digite `docker compose up --build`
espere buildar e inicar o programa no container
após isso digite em seu navegador http://localhost:8080
neste momento a aplicação estará disponivel



## Manual de uso

Rode no Live server
 Criar Ticket 
Insira as informações:
- Nome
- CPF 
- Descrição 

Clique no botão Enviar para gerar um ticket no banco de dados.

## Para Consultar "Meus Tickets"
Na pagina inicial clique no seguinte botão
Meus Tickets
preencha o campo com o CPF
neste momento a aplicação buscará no banco de dados tickets com o CPF correspondente e caso exista sera exibido na tela do usuario contendo os seguintes campos:
 - Nome
 - IP
 - Descrição do ticket

## Consulta de Metricas
 A pagina inicial contem uma barra de navegação com um link para a parte de metricas, nela contem as seguintes metricas:
 - Tickets abertos
 - Tickets Resolvidos
 - Tickets em andamento
 - Tickets cancelado
 - Problemas mais comuns

## API Externa
O valor do campo IP é capturado através de uma API externa onde existe a possibilidade de ficar Offline, caso isso ocorra:
o campo IP não será preenchido
Tente reiniciar a aplicação
Caso não resolva
Contactar o responsavel Gabriel pela equipe de TI.

