---
title: Exportar apresentações para XAML em Java
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Converter slides PowerPoint e OpenDocument para XAML em Java usando Aspose.Slides — solução rápida, sem necessidade do Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre o XAML**

XAML é uma linguagem de programação descritiva que permite criar ou escrever interfaces de usuário para aplicativos, especialmente aqueles que utilizam WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, que é uma linguagem baseada em XML, é a variante da Microsoft para descrever uma GUI. É provável que você use um designer para trabalhar em arquivos XAML na maior parte do tempo, mas ainda pode escrever e editar sua GUI.

## **Exportar apresentações para XAML com opções padrão**

Este código Java mostra como exportar uma apresentação para XAML com configurações padrão:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Exportar apresentações para XAML com opções personalizadas**

Você pode selecionar opções da interface [IXamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IXamlOptions) que controlam o processo de exportação e determinam como Aspose.Slides exporta sua apresentação para XAML. 

Por exemplo, se você quiser que Aspose.Slides adicione slides ocultos da sua apresentação ao exportá‑la para XAML, pode definir a propriedade [ExportHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) como true. Veja este exemplo de código Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **FAQ**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Defina [uma fonte padrão regular](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) em [XamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/) — ela é usada como fonte de fallback quando a original está ausente. Isso ajuda a evitar substituições inesperadas.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

XAML é uma linguagem de marcação de UI geral usada em WPF, UWP e Xamarin.Forms. A exportação visa compatibilidade com as pilhas XAML da Microsoft; o comportamento exato e o suporte a construções específicas dependem da plataforma de destino. Teste a marcação no seu ambiente.

**Slides ocultos são suportados e como posso impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) em [XamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/) — mantenha‑a desativada se não precisar exportá‑los.