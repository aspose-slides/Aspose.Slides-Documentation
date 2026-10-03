---
title: Introdução
type: docs
weight: 10
url: /pt/java/getting-started/
keywords:
- iniciando
- requisitos do sistema
- instalação
- primeira apresentação
- Maven
- processamento de PPT
- processamento de PPTX
- processamento de ODP
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "O caminho de um novo projeto Java até a primeira apresentação salva com Aspose.Slides: verifique os requisitos, adicione a biblioteca do repositório Maven da Aspose, execute um primeiro programa e continue com tarefas comuns."
---
## **Visão geral**

Execute as quatro etapas abaixo na ordem. Cada etapa indica o que fazer e vincula o artigo com os detalhes. Avaliação, licenciamento e suporte são abordados após as etapas.

## **Etapa 1: Verificar os Requisitos do Sistema**

Aspose.Slides for Java é um único arquivo JAR sem código nativo, portanto funciona em qualquer sistema operacional que tenha um runtime Java suportado. [Requisitos do Sistema](/slides/pt/java/system-requirements/) lista os sistemas operacionais e versões Java suportados. O projeto e os comandos nas próximas etapas precisam do JDK 11 ou posterior e, para a rota Maven, [Apache Maven](https://maven.apache.org/install.html).

## **Etapa 2: Adicionar a Biblioteca ao Seu Projeto**

Aspose.Slides for Java é publicado no próprio repositório Maven da Aspose, não no Maven Central. Escolha uma destas rotas:

- Com Maven: declare o repositório `https://releases.aspose.com/java/repo/` no seu *pom.xml* e adicione a dependência `com.aspose:aspose-slides` com o classificador `jdk16`.
- Sem Maven: faça download do arquivo JAR cujo nome termina em *-jdk16.jar* do repositório e coloque-o no classpath.

No Linux, instale também a biblioteca fontconfig e ao menos uma fonte. Sem elas, a gravação de uma apresentação falha com o erro "Fontconfig head is null, check your fonts or fonts configuration".

[Instalação](/slides/pt/java/installation/) fornece as entradas do *pom.xml*, o download do JAR e o comando para Linux.

## **Etapa 3: Criar Sua Primeira Apresentação**

O [início rápido na página inicial do Aspose.Slides for Java](/slides/pt/java/#your-first-presentation) é um projeto Maven completo: um arquivo *pom.xml* e um programa que adiciona uma forma de nuvem com texto a um slide e salva a apresentação como um arquivo PPTX. Você o executa com `mvn compile exec:java`. [Criar Apresentações](/slides/pt/java/create-presentation/) explica o mesmo programa passo a passo. Para abrir uma apresentação existente e salvá‑la em outro formato, veja [Abrir Apresentações](/slides/pt/java/open-presentation/) e [Salvar Apresentações](/slides/pt/java/save-presentation/).

## **Etapa 4: Continuar com Tarefas Comuns**

- [Abrir uma apresentação](/slides/pt/java/open-presentation/)
- [Salvar uma apresentação](/slides/pt/java/save-presentation/)
- [Converter uma apresentação para PDF](/slides/pt/java/convert-powerpoint-to-pdf/)
- [Renderizar slides como imagens](/slides/pt/java/convert-slide/)
- [Editar texto da apresentação](/slides/pt/java/manage-text/)
- [Exemplos por elemento de slide](/slides/pt/java/examples/)

## **Avaliar e Licenciar**

Sem uma licença, Aspose.Slides funciona em modo de avaliação: adiciona uma marca d'água a cada slide que salva e trunca o texto que seu código lê das apresentações.

- [Avaliar Aspose.Slides](/slides/pt/java/evaluate-aspose-slides/) descreve as limitações da avaliação e como solicitar uma licença temporária.
- [Licenciamento](/slides/pt/java/licensing/) mostra como aplicar uma licença a partir de um arquivo ou de um fluxo.
- [Licenciamento Medido](/slides/pt/java/metered-licensing/) aborda a licença cobrada por uso.
- [Formatos de Arquivo Suportados](/slides/pt/java/supported-file-formats/) lista os formatos que o Aspose.Slides pode carregar e salvar.

## **Obter Ajuda**

[Suporte Técnico](/slides/pt/java/technical-support/) explica como fazer uma pergunta no [fórum de suporte gratuito](https://forum.aspose.com/c/slides/pt/11) e o que incluir ao relatar um problema.

## **Perguntas Frequentes**

**Preciso ter o Microsoft PowerPoint instalado?**

Não. Aspose.Slides lê e grava arquivos de apresentação por conta própria e não usa o PowerPoint, portanto também funciona em servidores e no Linux.

**Por que o Maven não encontra o Aspose.Slides for Java?**

A biblioteca não está no Maven Central. Declare o repositório da Aspose no seu *pom.xml*, como mostrado em [Instalação](/slides/pt/java/installation/), e o Maven baixa a biblioteca a partir daí.

**O classificador `jdk16` significa que a biblioteca precisa do Java 16?**

Não. O classificador seleciona a compilação Java SE da biblioteca; a outra compilação é para Android. A mesma compilação funciona nos JDKs atuais, como o JDK 21.