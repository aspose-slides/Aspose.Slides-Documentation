---
title: Exportar Apresentações para XAML com Python
linktitle: Exportar para XAML
type: docs
weight: 30
url: /pt/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Converter slides de PowerPoint e OpenDocument para XAML em Python usando Aspose.Slides — solução rápida, sem necessidade do Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento da exportação de slides ocultos.

## **Sobre o XAML**

XAML é uma linguagem de programação descritiva que permite criar ou escrever interfaces de usuário para aplicativos, especialmente aqueles que utilizam WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.

XAML, que é uma linguagem baseada em XML, é a variante da Microsoft para descrever uma GUI. Você provavelmente usará um designer para trabalhar em arquivos XAML na maior parte do tempo, mas ainda pode escrever e editar sua GUI.

## **Exportar apresentações para XAML com opções padrão**

Este código Python mostra como exportar uma apresentação para XAML com as configurações padrão:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Exportar apresentações para XAML com opções personalizadas**

Você pode escolher opções da classe [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/) que controlam o processo de exportação e determinam como o Aspose.Slides exporta sua apresentação para XAML.

Por exemplo, se você quiser que o Aspose.Slides adicione slides ocultos da sua apresentação ao exportá‑la para XAML, pode definir a propriedade [export_hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) como `True`. Veja este exemplo de código Python:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Defina [default_regular_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) em [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/) — ela é usada como fonte de fallback quando a original está ausente. Isso ajuda a evitar substituições inesperadas.

**O XAML exportado é destinado apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

XAML é uma linguagem de marcação UI geral usada em WPF, UWP e Xamarin.Forms. A exportação visa compatibilidade com as pilhas XAML da Microsoft; o comportamento exato e o suporte a construções específicas dependem da plataforma de destino. Teste a marcação no seu ambiente.

**Slides ocultos são suportados e como posso impedir que eles sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [export_hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) em [XamlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export.xaml/xamloptions/) — mantenha-a desativada se não precisar exportá‑los.