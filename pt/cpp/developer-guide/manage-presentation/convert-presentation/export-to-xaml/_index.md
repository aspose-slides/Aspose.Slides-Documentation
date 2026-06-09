---
title: Exportar apresentações para XAML em C++
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Converta slides de PowerPoint e OpenDocument para XAML em C++ usando Aspose.Slides—solução rápida, sem Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/), inclusive exportando slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre o XAML**

XAML é uma linguagem de programação descritiva que permite criar ou escrever interfaces de usuário para aplicativos, especialmente aqueles que utilizam WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, que é uma linguagem baseada em XML, é a variante da Microsoft para descrever uma GUI. Você provavelmente usará um designer para trabalhar em arquivos XAML na maior parte do tempo, mas ainda pode escrever e editar sua GUI.

## **Exportar apresentações para XAML com opções padrão**

Este código C++ mostra como exportar uma apresentação para XAML com as configurações padrão:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Exportar apresentações para XAML com opções personalizadas**

Você pode selecionar opções da interface [IXamlOptions](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.xaml.i_xaml_options) que controlam o processo de exportação e determinam como o Aspose.Slides exporta sua apresentação para XAML. 

Por exemplo, se quiser que o Aspose.Slides adicione slides ocultos da sua apresentação ao exportá‑la para XAML, pode passar true para o método [set_ExportHiddenSlides()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Veja este exemplo de código C++:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **FAQ**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Use [set_DefaultRegularFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) em [XamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/) — ele é usado como fonte de fallback quando a original está ausente. Isso ajuda a evitar substituições inesperadas.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

XAML é uma linguagem de marcação de UI geral usada em WPF, UWP e Xamarin.Forms. A exportação visa compatibilidade com as pilhas XAML da Microsoft; o comportamento exato e o suporte a construções específicas dependem da plataforma de destino. Teste a marcação no seu ambiente.

**Slides ocultos são suportados e como impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [set_ExportHiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) em [XamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/) — mantenha‑lo desativado se não precisar exportá‑los.