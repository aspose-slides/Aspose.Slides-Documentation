---
title: "Como extrair texto de arquivos PPT, PPTX e ODP usando o Open XML SDK no .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /pt/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- plataformas de nuvem
- integração de nuvem
- Open XML SDK
- extração de texto PPTX
- processamento de slides .NET
- extração de texto de apresentação
- slide mestre
- notas do apresentador
- extraindo texto de slides
- C#
description: "Aprenda como extrair texto de PPT, PPTX e ODP no .NET usando o Open XML SDK, com acesso baseado em XML, dicas de desempenho e soluções de conversão para aplicativos em nuvem."
---
## **Visão geral**

Este artigo explica como extrair texto de arquivos de apresentação usando o Open XML SDK no .NET. Ele se concentra no acesso direto ao XML para arquivos PPTX, onde o texto pode ser recuperado de elementos de slide estruturados sem renderizar os slides ou exigir o Microsoft PowerPoint. O artigo também descreve benefícios de desempenho, como processamento mais rápido e menor uso de memória.

Para arquivos PPT e ODP, o artigo explica que o texto não pode ser extraído diretamente com o Open XML SDK. Em vez disso, esses formatos devem primeiro ser convertidos para PPTX, após o que o texto pode ser extraído do arquivo resultante.

## **Open XML SDK**

O **Open XML SDK** fornece um método altamente estruturado e eficiente para extrair texto de arquivos de apresentação — especialmente **PPTX**, que segue o padrão Open XML. Ao oferecer acesso direto ao XML subjacente, esse SDK permite um manuseio mais rápido e flexível do conteúdo dos slides em comparação com métodos tradicionais.

## **Acesso direto ao XML**

- **Analisar texto diretamente**: O Open XML SDK permite extrair texto das partes XML sem renderizar slides.  
- **Elementos estruturados**: Como o texto é armazenado em tags XML bem definidas, fica mais simples recuperá‑lo e processá‑lo.

### **Exemplo: Extraindo texto diretamente do conteúdo XML do slide**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **Vantagens de desempenho**

- **Extração mais rápida**: Contorna a sobrecarga de abrir o PowerPoint ou outras APIs de alto nível.  
- **Menor uso de memória**: Apenas as partes XML relevantes são acessadas, reduzindo o consumo de recursos.  
- **Não é necessário o Microsoft PowerPoint**: Libera você de requisitos adicionais de instalação.

### **Exemplo: Extraindo texto de forma eficiente sem carregar toda a apresentação**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **Identificando elementos de texto**

### **Especificidades da extração de texto de apresentações**

Ao extrair texto de apresentações, considere estes fatores:

- **O texto pode estar em diferentes seções**: Slides regulares, slides mestre, layouts ou notas do apresentador.  
- **Marcadores de posição padrão**: Slides mestre e layouts podem incluir marcadores (por exemplo, “Click to edit Master title style”) que não são conteúdo real da apresentação.  
- **Filtrando texto vazio ou oculto**: Alguns elementos podem estar vazios ou não destinados à exibição.

### **Tags que contêm texto**

Em um arquivo **PPTX**, o texto geralmente é armazenado em:

- elementos `<a:t>` dentro de `<a:p>` (parágrafos)  
- elementos `<a:r>` (segmentos de texto dentro de parágrafos)

### **Exemplo: Extraindo todos os elementos de texto de um slide**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP e PPT**

### **Incapacidade de extrair texto diretamente**

- Ao contrário do **PPTX**, **PPT** (formato binário) e **ODP** (Apresentação OpenDocument) **não são suportados** pelo Open XML SDK.  
- **PPT** armazena o conteúdo em um formato binário fechado, complicando a extração de texto.  
- **ODP** baseia‑se no **OpenDocument XML**, que difere estruturalmente do PPTX.

### **Solução alternativa: Convertendo para PPTX**

Para extrair texto de **PPT** ou **ODP**, a abordagem recomendada é:

1. **Converter PPT → PPTX** usando o PowerPoint ou uma ferramenta de terceiros.  
2. **Converter ODP → PPTX** via LibreOffice ou PowerPoint.  
3. **Extrair texto** do novo PPTX usando o Open XML SDK.

### **Exemplo: Convertendo ODP para PPTX via linha de comando do LibreOffice**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Plataformas e frameworks suportados**

- **Windows**: .NET Framework 4.6.1 e superiores, .NET Core 2.1+, .NET 5/6/7.  
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.  
- **Ambientes de nuvem**: Microsoft Azure Functions, AWS Lambda (.NET Core), contêineres Docker.  
- **Compatibilidade com aplicativos Office**: Não é necessária a instalação do Microsoft Office.  
- **Linguagens de programação suportadas**: O Open XML SDK pode ser usado com **C#**, **VB.NET**, **F#** e outras linguagens suportadas pelo .NET.

## **Conclusão**

Aproveitar o **Open XML SDK** para **extração de texto de PPTX** oferece tanto eficiência quanto clareza, enquanto **PPT e ODP** exigem uma etapa inicial de conversão para um processamento tranquilo. Adotar essa abordagem garante **alto desempenho**, **flexibilidade** e **ampla compatibilidade** com aplicações .NET modernas.