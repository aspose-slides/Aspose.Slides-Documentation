---
title: Segurança
type: docs
weight: 160
url: /pt/java/security/
keywords:
- segurança
- dependências
- componentes de terceiros
- Maven
- assinatura JAR
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise como o Aspose.Slides for Java processa apresentações, o que ele adiciona às dependências do seu projeto, como verificar o arquivo JAR e quais componentes de terceiros ele inclui."
---
## **Introdução**

Este artigo reúne as informações que normalmente são necessárias em uma revisão de segurança de um aplicativo que utiliza o Aspose.Slides for Java: como a biblioteca processa apresentações, o que ela adiciona às dependências do seu projeto, como verificar se o arquivo JAR provém da Aspose e quais componentes de terceiros o JAR contém.

## **Segurança no Aspose.Slides**

A Aspose aplica as melhores práticas ao desenvolver seus produtos.

* Aspose.Slides for Java é usado para criar, modificar e converter apresentações. Ele não executa scripts em apresentações. O Aspose.Slides analisa a estrutura da apresentação e permite que seu código trabalhe com o modelo de objetos.
* Aspose.Slides funciona como uma biblioteca que analisa e interpreta documentos sem executar código remoto. Todos os produtos Aspose são executados nas suas máquinas. Eles não transmitem nenhum dado para a Aspose. A única exceção é a [metered licensing](/slides/pt/java/metered-licensing/): se você a utilizar, somente as informações de uso da API são processadas.
* Os componentes Aspose são executados no mesmo contexto de usuário que aplicativos regulares. Portanto, os componentes Aspose não representam risco para recursos críticos do sistema. Além disso, quando um componente Aspose abre um documento, macros não são executadas automaticamente.

## **Dependências Maven**

O artefato Maven do Aspose.Slides for Java, `com.aspose:aspose-slides`, não declara dependências: seu arquivo POM contém apenas as coordenadas do próprio artefato. Ao adicioná‑lo a um projeto, o Maven inclui apenas este único arquivo JAR e nada mais. Para listar todos os artefatos que seu projeto resolve, incluindo dependências transitivas, execute este comando na pasta do projeto:

```bash
mvn dependency:tree
```

No projeto de [Installation](/slides/pt/java/installation/), a saída lista o Aspose.Slides como a única dependência:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verificar o Arquivo JAR**

A Aspose assina o arquivo JAR. Para verificar a assinatura, execute a ferramenta `jarsigner` do JDK na pasta que contém o arquivo JAR:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

O comando imprime `jar verified.` quando a assinatura é válida e nenhuma entrada foi alterada desde que o arquivo foi assinado. Esta mensagem não indica o nome do assinante. Para confirmar que a Aspose assinou o arquivo, adicione as opções `-verbose` e `-certs` e verifique que o certificado do assinante foi emitido para `CN=ASPOSE PTY LTD`. Quando o Maven baixa o arquivo JAR, ele também verifica a soma de verificação SHA‑1 que o repositório publica ao lado do arquivo.

## **Componentes de Terceiros**

O Aspose.Slides for Java inclui código e dados de componentes de terceiros. Eles fazem parte do arquivo JAR, não de artefatos Maven separados, portanto `mvn dependency:tree` e outras ferramentas que leem dependências Maven não os listam. O arquivo JAR contém o aviso *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, que enumera os componentes e suas licenças:

| Componente | Licença declarada no aviso |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | licença estilo MIT |
| Mono | licença MIT; algumas partes sob outras licenças que o aviso lista |
| RSWOP.ICM color profile | termos de licença da Microsoft |
| sRGB_v4_ICC_preference.icc color profile | permissão ICC para usar, copiar e distribuir o arquivo sem alterações |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Para extrair o aviso do arquivo JAR, execute a ferramenta `jar` do JDK na pasta que contém o arquivo JAR:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**O Aspose.Slides for Java usa pacotes externos?**

Ele não tem dependências Maven, como mostra [Dependências Maven](#maven-dependencies), mas inclui os componentes de terceiros listados em [Componentes de Terceiros](#third-party-components). Inclua tanto o arquivo JAR quanto esses componentes em sua revisão de segurança.

**O Aspose.Slides for Java precisa de acesso à rede?**

Não. Criar, salvar e renderizar apresentações funciona em um sistema sem nenhuma conexão de rede. O único recurso que envia dados para a Aspose é a [metered licensing](/slides/pt/java/metered-licensing/), que relata o uso da API.

**O Aspose.Slides for Java contém código nativo?**

Não. O arquivo JAR contém apenas classes e recursos Java, portanto não adiciona bibliotecas nativas ao seu aplicativo. No Linux, o suporte a fontes da runtime Java necessita da biblioteca fontconfig e das fontes do sistema operacional; veja [System Requirements](/slides/pt/java/system-requirements/#linux).