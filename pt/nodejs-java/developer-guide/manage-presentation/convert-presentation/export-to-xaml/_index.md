---
title: Exportar Apresentações para XAML em JavaScript
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter slides de PowerPoint e OpenDocument para XAML em JavaScript usando Aspose.Slides para Node.js—solução rápida, sem Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade com pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre o XAML**

XAML é uma linguagem de programação descritiva que permite criar ou escrever classes de usuário para apps, especialmente aqueles que usam WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.

XAML, que é uma linguagem baseada em XML, é a variante da Microsoft para descrever uma interface gráfica. É provável que você use um designer para trabalhar nos arquivos XAML na maior parte do tempo, mas ainda pode escrever e editar sua interface gráfica.

## **Exportando Apresentações para XAML com Opções Padrão**

Este código JavaScript mostra como exportar uma apresentação para XAML com as configurações padrão:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exportando Apresentações para XAML com Opções Personalizadas**

Você pode selecionar opções da classe [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/XamlOptions) que controlam o processo de exportação e determinam como o Aspose.Slides exporta sua apresentação para XAML.

Por exemplo, se desejar que o Aspose.Slides adicione slides ocultos da sua apresentação ao exportá‑la para XAML, pode definir o método [setExportHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) como true. Veja este código de exemplo em JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Use [setDefaultRegularFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/) — ele é usado como fonte de fallback quando a original está ausente. Isso ajuda a evitar substituições inesperadas.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

XAML é uma linguagem de marcação de UI geral usada em WPF, UWP e Xamarin.Forms. A exportação visa compatibilidade com as pilhas XAML da Microsoft; o comportamento exato e o suporte a construções específicas dependem da plataforma de destino. Teste a marcação no seu ambiente.

**Slides ocultos são suportados e como posso impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) em [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/) — mantenha a opção desativada se não precisar exportá‑los.