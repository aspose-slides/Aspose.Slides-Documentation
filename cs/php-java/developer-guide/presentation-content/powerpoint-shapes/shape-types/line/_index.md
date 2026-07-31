---
title: Přidání čarových tvarů do prezentací v PHP
linktitle: Čára
type: docs
weight: 50
url: /cs/php-java/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- prostá čára
- konfigurovat čáru
- přizpůsobit čáru
- styl čáry
- hlavice šipky
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides for PHP via Java. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat čárové tvary do snímků PowerPoint. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak upravit čáru tak, aby vypadala jako šipka.

Dozvíte se, jak přidat tvar čáry do snímku, upravit jeho vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako jsou styl, šířka, vzor čáry, možnosti koncových šipek a barva výplně.

## **Vytvoření prosté čáry**

Chcete‑li do vybraného snímku prezentace přidat jednoduchou prostou čáru, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape) poskytované objektem [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```php
  # Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidejte AutoShape typu čára
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Uložte soubor PPTX na disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vytvoření čáry ve tvaru šipky**

Aspose.Slides for PHP via Java také umožňuje vývojářům nakonfigurovat některé vlastnosti čáry, aby vypadala atraktivněji. Pojďme nakonfigurovat několik vlastností čáry, aby vypadala jako šipka. Postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape) poskytované objektem [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
- Nastavte [Line Style](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LineStyle) na jeden ze stylů nabízených Aspose.Slides for PHP via Java.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LineDashStyle) čáry na jeden ze stylů nabízených Aspose.Slides for PHP via Java.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LineArrowheadLength) počátečního bodu čáry.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LineArrowheadLength) koncového bodu čáry.
- Uložte upravenou prezentaci jako soubor PPTX.

```php
  # Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získejte první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidejte AutoShape typu čára
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Aplikujte na čáru nějaké formátování
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Uložte soubor PPTX na disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu převést běžnou čáru na spojku, aby se „přichytávala“ k tvarům?**

Ne. Běžná čára ( [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapetype/)) se automaticky nepřevede na spojku. Chcete‑li, aby se přichytávala k tvarům, použijte dedikovaný typ [Connector](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/) a [corresponding APIs](/slides/cs/php-java/connector/) pro připojení.

**Co mám dělat, pokud jsou vlastnosti čáry zděděny z motivu a je obtížné určit konečné hodnoty?**

[Read the effective properties](/slides/cs/php-java/shape-effective-properties/) pomocí `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — tyto již zohledňují dědičnost a styly motivu.

**Mohu uzamknout čáru proti úpravám (přesouvání, změně velikosti)?**

Ano. Tvary poskytují [lock objects](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/getautoshapelock/), které umožňují zakázat operace úprav.