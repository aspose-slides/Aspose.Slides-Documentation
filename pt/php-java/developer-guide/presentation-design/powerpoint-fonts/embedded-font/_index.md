---
title: Incorporar fontes em apresentações usando PHP
linktitle: Incorporar fonte
type: docs
weight: 40
url: /pt/php-java/embedded-font/
keywords:
- adicionar fonte
- incorporar fonte
- incorporação de fonte
- obter fonte incorporada
- adicionar fonte incorporada
- remover fonte incorporada
- compactar fonte incorporada
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Incorpore fontes TrueType em apresentações PowerPoint e OpenDocument com Aspose.Slides para PHP via Java, garantindo renderização precisa em todas as plataformas."
---
## **Introdução**

**Fontes incorporadas no PowerPoint** são úteis quando você deseja que sua apresentação apareça corretamente ao ser aberta em qualquer sistema ou dispositivo. Se você usou uma fonte de terceiros ou não padrão porque foi criativo no seu trabalho, então tem ainda mais motivos para incorporar sua fonte. Caso contrário (sem fontes incorporadas), os textos ou números em seus slides, o layout, o estilo, etc. podem mudar ou se transformar em retângulos confusos.

A classe [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontsManager) , a classe [FontData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontdata/) e a classe [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/) contêm a maioria dos métodos de que você precisa para trabalhar com fontes incorporadas em apresentações do PowerPoint.

## **Obter e remover fontes incorporadas**

Aspose.Slides fornece o método [getEmbeddedFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (exposto pela classe [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontsManager)) para permitir que você obtenha (ou descubra) as fontes incorporadas em uma apresentação. Para remover fontes, utiliza-se o método [removeEmbeddedFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (exposto pela mesma classe).

Este código PHP mostra como obter e remover fontes incorporadas de uma apresentação:

```php
  # Instancia um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Renderiza um slide contendo um quadro de texto que usa a fonte incorporada "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Salva a imagem no disco no formato JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Obtém todas as fontes incorporadas
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Encontra a fonte "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Remove a fonte "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Renderiza a apresentação; a fonte "Calibri" é substituída por uma existente
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Salva a imagem no disco no formato JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Salva a apresentação sem a fonte "Calibri" incorporada no disco
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar fontes incorporadas**

Usando a classe [EmbedFontCharacters](https://reference.aspose.com/slides/pt/php-java/aspose.slides/embedfontcharacters/) e duas sobrecargas do método [addEmbeddedFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), você pode selecionar a regra de incorporação que preferir para incorporar as fontes em uma apresentação. Este código PHP mostra como incorporar e adicionar fontes a uma apresentação:

```php
  # Carrega a apresentação
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Salva a apresentação no disco
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Compactar fontes incorporadas**

Para permitir que você compacte as fontes incorporadas em uma apresentação e reduza o tamanho do arquivo, Aspose.Slides fornece o método [compressEmbeddedFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#compressEmbeddedFonts) (exposto pela classe [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/)).

Este código PHP mostra como compactar fontes incorporadas do PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Como posso saber se uma fonte específica na apresentação ainda será substituída durante a renderização, apesar de estar incorporada?**

Verifique as [informações de substituição](/slides/pt/php-java/font-substitution/) no gerenciador de fontes e as [regras de fallback/substituição](/slides/pt/php-java/fallback-font/): se a fonte estiver indisponível ou restrita, um fallback será usado.

**Vale a pena incorporar fontes "do sistema" como Arial/Calibri?**

Normalmente não — elas estão quase sempre disponíveis. Mas para total portabilidade em ambientes "leves" (Docker, um servidor Linux sem fontes pré‑instaladas), incorporar fontes do sistema pode eliminar o risco de substituições inesperadas.