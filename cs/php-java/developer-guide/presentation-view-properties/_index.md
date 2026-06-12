---
title: Načtení a aktualizace vlastností zobrazení prezentace v PHP
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/php-java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý dělič
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro PHP přes Java, které umožňují přizpůsobit formáty PPT, PPTX a ODP snímků – upravit rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění jednotlivých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uloženo.

Metoda [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) byla přidána pro poskytování přístupu k vlastnostem normálního zobrazení prezentace.

Byly přidány třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties), jejich potomci a výčet [SplitterBarStateType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType) .

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metoda [getShowOutlineIcons](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) a metoda [setShowOutlineIcons](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu v režimu normálního zobrazení.

Metoda [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) a metoda [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) určují, zda se má svislý dělič přichytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) a metoda [setPreferSingleView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) určují, zda uživatel upřednostňuje zobrazit jednorozměrnou oblast obsahu na celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metoda [getVerticalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) a metoda [getHorizontalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) určují stav, ve kterém by měl být zobrazen vodorovný nebo svislý dělič. Vodorovný dělič odděluje snímek od oblasti obsahu pod snímkem, svislý dělič odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Maximized) a [SplitterBarStateType::Restored](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metoda [getRestoredLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) a metoda [getRestoredTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties#getRestoredTop) určují velikost horní nebo postranní oblasti snímku v normálním zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) použita hodnota [SplitterBarStateType::Restored](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Restored).

## **O obnovování INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), výška, pokud je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) v normálním zobrazení, když má oblast proměnnou obnovovanou velikost (není ani minimalizovaná, ani maximalizovaná).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) určuje velikost oblasti snímku (šířka, pokud je podřízená restoredTop, výška, pokud je podřízená restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat vlastnosti [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) pro prezentaci.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Obnovit vlastnosti zobrazení prezentace
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Nastavení výchozí úrovně přiblížení**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java nyní podporuje nastavení výchozí úrovně přiblížení pro prezentaci tak, že při otevření je přiblížení již nastaveno. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) v [Aspose.Slides](/slides/cs/).

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) . V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i zobrazení poznámek.

```php
  $presentation = new Presentation();
  try {
    # Nastavení vlastností zobrazení prezentace
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Hodnota přiblížení v procentech pro zobrazení snímku
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Hodnota přiblížení v procentech pro zobrazení poznámek

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Často kladené otázky**

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getviewproperties/) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nikoli pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílená. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getviewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.