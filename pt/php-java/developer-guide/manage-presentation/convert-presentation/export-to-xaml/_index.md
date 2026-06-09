---
title: Exportar apresentações para XAML em PHP
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Converta slides PowerPoint e OpenDocument para XAML usando Aspose.Slides para PHP via Java — solução rápida, sem necessidade do Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de reserva, compatibilidade de pilhas XAML e comportamento da exportação de slides ocultos.

## **Sobre XAML**

XAML é uma linguagem de programação descritiva que permite criar ou escrever interfaces de usuário para aplicativos, especialmente aqueles que utilizam WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin Forms.  

XAML, que é uma linguagem baseada em XML, é a variante da Microsoft para descrever uma GUI. Você provavelmente usará um designer para trabalhar em arquivos XAML na maior parte do tempo, mas ainda pode escrever e editar sua interface gráfica. 

## **Exportar apresentações para XAML com opções padrão**

Este código PHP mostra como exportar uma apresentação para XAML com as configurações padrão:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Exportar apresentações para XAML com opções personalizadas**

Você pode selecionar opções da classe [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/) que controlam o processo de exportação e determinam como o Aspose.Slides exporta sua apresentação para XAML.

Por exemplo, se você quiser que o Aspose.Slides adicione slides ocultos da sua apresentação ao exportá‑la para XAML, pode usar o método [setExportHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/setexporthiddenslides/) com o valor `true`. Veja este exemplo de código PHP:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Defina [uma fonte regular padrão](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/) — ela é usada como fonte de reserva quando a original está ausente. Isso ajuda a evitar substituições inesperadas.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

XAML é uma linguagem de marcação de interface de usuário geral usada em WPF, UWP e Xamarin.Forms. A exportação tem como alvo a compatibilidade com as pilhas XAML da Microsoft; o comportamento exato e o suporte a construções específicas dependem da plataforma de destino. Teste a marcação no seu ambiente.

**Slides ocultos são suportados e como posso impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/setexporthiddenslides/) em [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/) — mantenha‑o desativado se não precisar exportá‑los.