---
title: Segurança
type: docs
weight: 160
url: /pt/net/security/
keywords:
- segurança
- dependências
- componentes de terceiros
- NuGet
- varredura de vulnerabilidades
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Reveja como o Aspose.Slides para .NET processa apresentações, quais pacotes NuGet ele depende para cada estrutura de destino e quais componentes de terceiros ele inclui."
---
## **Segurança no Aspose.Slides**

A Aspose aplica as melhores práticas ao desenvolver seus produtos.

* O Aspose.Slides para .NET é usado para manipular apresentações e convertê‑las para outros formatos. Ele não executa scripts nas apresentações. O Aspose.Slides analisa a estrutura da apresentação e permite que o código do usuário final manipule o modelo de objetos de forma conveniente.
* O Aspose.Slides funciona como uma biblioteca que analisa e interpreta documentos sem executar código remoto. Todos os produtos Aspose são executados nas suas máquinas. Eles não transmitem nenhum dado para a Aspose. A única exceção é uma [licença medida](https://purchase.aspose.com/faqs/licensing/metered): se você usar uma, somente as informações de uso da API são processadas.
* Os componentes Aspose são executados no mesmo contexto de usuário que aplicativos normais. Portanto, os componentes Aspose não representam risco para recursos críticos do sistema. Além disso, ao abrir um documento, um componente Aspose não executa macros automaticamente.
* Os riscos inerentes ou associados ao pacote Microsoft Office não se aplicam aos componentes Aspose, portanto os produtos Aspose são muito seguros.

## **Dependências do NuGet**

Aspose.Slides para .NET depende de pacotes que a Microsoft publica no NuGet. As dependências variam de acordo com o pacote e a estrutura de destino:

| Pacote | Estrutura de destino | Dependências |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

A seção **Dependencies** da página do [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) e da página do [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) no NuGet lista a versão mínima de cada dependência para cada versão.

Quando você adiciona o Aspose.Slides a um projeto, o NuGet também restaura as dependências desses pacotes. Para listar todos os pacotes que seu projeto restaura, incluindo essas dependências transitivas, execute este comando na pasta do projeto:

```bash
dotnet list package --include-transitive
```

Para verificar o mesmo conjunto de pacotes em relação a vulnerabilidades conhecidas, execute:

```bash
dotnet list package --vulnerable --include-transitive
```

Para outras formas de auditar pacotes NuGet, veja [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Componentes de Terceiros**

O Aspose.Slides inclui código de componentes de código‑aberto de terceiros. Eles fazem parte do produto, não são pacotes NuGet separados, portanto as ferramentas que leem apenas dependências NuGet não os listam. Ambos os pacotes contêm o arquivo *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, que lista os componentes e suas licenças:

| Componente | Licença declarada no aviso |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **Perguntas Frequentes**

**Quais sistemas são usados para monitorar vulnerabilidades no código da Aspose?**

Executamos uma análise de código estático para cada versão do Aspose.Slides. Podemos fornecer relatórios de segurança que comprovam que o código do Aspose.Slides atende ao OWASP Top 10.

**O Aspose.Slides usa pacotes externos?**

Sim. Ele depende dos pacotes NuGet da Microsoft listados em [NuGet Dependencies](#nuget-dependencies) e inclui os componentes de terceiros listados em [Third-Party Components](#third-party-components). Inclua ambos em sua revisão de segurança e use `dotnet list package --vulnerable --include-transitive` para verificar os pacotes NuGet que seu projeto restaura.