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
- přichytit svislý oddělovač
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí zvětšení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro PHP via Java a přizpůsobte formáty snímků PPT, PPTX a ODP — upravte rozvržení, úrovně přiblížení a nastavení zobrazování."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo posledně uloženo.

Metoda [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) byla přidána, aby poskytla přístup k vlastnostem normálního zobrazení prezentace.

Třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties) a jejich potomci, enum [SplitterBarStateType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType) byly přidány.

## **O INormalViewProperties**

Zastupuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) určují, zda se má svislý oddělovač přichytit do zmenšeného stavu, když je boční oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) a [setPreferSingleView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) určuje, zda uživatel upřednostňuje zobrazení jedné celé okna s jedinou oblastí obsahu před standardním normálním zobrazením se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) určují stav, ve kterém má být zobrazen svislý nebo vodorovný oddělovač. Vodorovný oddělovač odděluje snímek od oblasti obsahu pod snímkem, svislý oddělovač odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Maximized) a [SplitterBarStateType::Restored](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) a [getRestoredTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties#getRestoredTop) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) použita hodnota [SplitterBarStateType::Restored](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Restored).

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je dítětem [getRestoredTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), výška, když je dítětem [getRestoredLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) v normálním zobrazení, když má oblast proměnnou obnovenou velikost (není zmenšená ani maximalizovaná).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) určuje velikost oblasti snímku (šířka, když je dítětem restoredTop, výška, když je dítětem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně rozměrů okna obsahujícího zobrazení v aplikaci.

Níže uvedený příklad ukazuje, jak můžete získat přístup k vlastnostem [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) pro prezentaci.

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

## **Nastavení výchozí hodnoty přiblížení**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby byla při otevření prezentace již nastavena. Toto lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) v Aspose.Slides.

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   V příkladu níže jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

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

## **Nastavení rozestupu mřížky**

Použijte [Presentation::getViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getViewProperties) k přístupu k nastavením zobrazení na úrovni celé prezentace. Metody [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/#getGridSpacing) a [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/#setGridSpacing) čtou nebo mění interval základní editační mřížky. Toto nastavení platí pro celou prezentaci, ne pro jednotlivý snímek. Rozestup mřížky je udáván v bodech, kde 72 bodů odpovídá jednomu palci. Používejte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtinového palce a uloží výsledek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mřížka se liší od [drawing guides](/slides/cs/php-java/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodicí čáry jsou individuálně umístěné vodorovné nebo svislé zarovnávací linie. Přidání, přesunutí nebo vymazání vodicích čar nemění rozestup mřížky.

Obě, mřížka i vodicí čáry, jsou pomůcky při úpravách. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani v prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodicích čar rozestup mřížky?**

Ne. Vodicí čáry a rozestup mřížky jsou nezávislá nastavení. Vymazání čar ponechává uložený interval mřížky nezměněný.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getviewproperties/) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nikoli pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getviewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet nové dokumenty se stejnou počáteční konfigurací zobrazení.