---
title: Exportar apresentações para XAML em .NET
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/net/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar apresentação
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- PowerPoint para XAML
- OpenDocument para XAML
- apresentação para XAML
- PPT para XAML
- PPTX para XAML
- ODP para XAML
- salvar PPT como XAML
- salvar PPTX como XAML
- salvar ODP como XAML
- exportar PPT para XAML
- exportar PPTX para XAML
- exportar ODP para XAML
- .NET
- C#
- Aspose.Slides
description: "Converter slides PowerPoint e OpenDocument para XAML em .NET usando Aspose.Slides—solução rápida, sem Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre XAML**

XAML é uma linguagem de programação descritiva que permite criar ou escrever interfaces de usuário para aplicativos, especialmente aqueles que utilizam WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin forms.  

XAML, que é uma linguagem baseada em XML, é a variante da Microsoft para descrever uma GUI. Você provavelmente usará um designer para trabalhar nos arquivos XAML na maior parte do tempo, mas ainda pode escrever e editar sua GUI. 

## **Exportar apresentações para XAML com opções padrão**

Este código C# mostra como exportar uma apresentação para XAML com as configurações padrão:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Exportar apresentações para XAML com opções personalizadas**

Você pode selecionar opções da interface [IXamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/ixamloptions) que controlam o processo de exportação e determinam como o Aspose.Slides exporta sua apresentação para XAML. 

Por exemplo, se você quiser que o Aspose.Slides adicione slides ocultos da sua apresentação ao exportá-la para XAML, pode definir a propriedade [ExportHiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) como true. Veja este exemplo de código C#: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **FAQ**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Defina [DefaultRegularFont](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/defaultregularfont/) em [XamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/) — ele é usado como fonte de fallback quando a original está ausente. Isso ajuda a evitar substituições inesperadas.

**O XAML exportado se destina apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

XAML é uma linguagem de marcação de UI geral usada em WPF, UWP e Xamarin.Forms. A exportação tem como alvo a compatibilidade com as pilhas XAML da Microsoft; o comportamento exato e o suporte a construções específicas dependem da plataforma de destino. Teste a marcação em seu ambiente.

**Os slides ocultos são suportados e como posso impedir que eles sejam exportados por padrão?**

Por padrão, os slides ocultos não são incluídos. Você pode controlar esse comportamento via [ExportHiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) em [XamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/) — mantenha-o desativado se não precisar exportá-los.