---
title: Přidání tvarů čar do prezentací v PHP
linktitle: Čára
type: docs
weight: 50
url: /cs/php-java/Line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- prostá čára
- nastavit čáru
- přizpůsobit čáru
- styl čárkování
- šipková hlava
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se upravovat formátování čar v prezentacích PowerPoint pomocí Aspose.Slides for PHP via Java. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides umožňuje programově přidávat tvarové čáry do snímků PowerPointu. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji přizpůsobit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat tvar čáry na snímek, upravit její vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako jsou styl, šířka, vzor čárkování, možnosti hrotu šipky a barva výplně.

## **Vytvoření prosté čáry**

Chcete‑li přidat jednoduchou prostou čáru do vybraného snímku prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape), kterou poskytuje objekt [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
- Uložte upravenou prezentaci jako soubor PPTX.

V ukázkovém příkladu níže jsme přidali čáru na první snímek prezentace.

```php
  # Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získat první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidat AutoShape typu line
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Uložit PPTX na disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vytvoření čáry ve tvaru šipky**

Aspose.Slides for PHP via Java také umožňuje vývojářům konfigurovat některé vlastnosti čáry, aby vypadala atraktivněji. Zkuste nakonfigurovat několik vlastností čáry tak, aby připomínala šipku. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape), kterou poskytuje objekt [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/).
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
    # Získat první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidat AutoShape typu line
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Použít nějaké formátování na čáře
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Uložit PPTX na disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu převést běžnou čáru na spojku, aby se „přichytávala“ k tvarům?**

Ne. Běžná čára (AutoShape typu [Line](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapetype/)) se automaticky nepřemění na spojku. Pro přichytávání k tvarům použijte specializovaný typ [Connector](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/) a [příslušná API](/slides/cs/php-java/connector/) pro spojení.

**Co mám dělat, když jsou vlastnosti čáry zděděny z motivu a je obtížné zjistit konečné hodnoty?**

[Přečtěte si efektivní vlastnosti](/slides/cs/php-java/shape-effective-properties/) pomocí `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — ty již zahrnují dědičnost a styly motivu.

**Mohu uzamknout čáru proti úpravám (přesouvání, změna velikosti)?**

Ano. Tvary poskytují [objekty uzamčení](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/getautoshapelock/), které umožňují zakázat operace úprav.