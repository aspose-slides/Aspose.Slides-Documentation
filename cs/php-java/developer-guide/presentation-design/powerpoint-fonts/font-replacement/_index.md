---
title: Zjednodušte nahrazování písem v prezentacích pomocí PHP
linktitle: Nahrazování písem
type: docs
weight: 60
url: /cs/php-java/font-replacement/
keywords:
- písmo
- nahradit písmo
- nahrazení písma
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Bezproblémově nahraďte písma v Aspose.Slides pro PHP pomocí Javy, abyste zajistili konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides umožňuje nahradit jedno písmo jiným v celé prezentaci. Když je písmo nahrazeno, všechny instance původního písma se změní na nové písmo.

Pro provedení nahrazení písma načtěte prezentaci, určete zdrojové písmo a písmo náhrady, zavolejte metodu pro nahrazení písma a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když úmyslně chcete přepnout z jedné rodiny písma na druhou v celé prezentaci.

## **Nahrazení písem**

Pokud změníte názor na používání písma, můžete toto písmo nahradit jiným písmem. Všechny instance starého písma budou nahrazeny novým písmem.

Aspose.Slides umožňuje nahrazení písma následujícím způsobem:

1. Načtěte příslušnou prezentaci.  
2. Načtěte písmo, které bude nahrazeno.  
3. Načtěte nové písmo.  
4. Proveďte nahrazení písma.  
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje nahrazení písma:

```php
  # Načte prezentaci
  $pres = new Presentation("Fonts.pptx");
  try {
    # Načte zdrojové písmo, které bude nahrazeno
    $sourceFont = new FontData("Arial");
    # Načte nové písmo
    $destFont = new FontData("Times New Roman");
    # Nahradí písma
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Uloží prezentaci
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Poznámka" color="warning" %}} 
Chcete-li nastavit pravidla, která určují, co se stane v určitých podmínkách (například pokud není písmo dostupné), podívejte se na [**Substituce písma**](/slides/cs/php-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Jaký je rozdíl mezi „náhradou písma“, „substitucí písma“ a „záložními písmy“?**

Náhrada je úmyslný přechod z jedné rodiny na druhou v celém dokumentu. [Substituce](/slides/cs/php-java/font-substitution/) je pravidlo typu „pokud není písmo dostupné, použij X.“ [Záložní písmo](/slides/cs/php-java/fallback-font/) se aplikuje cíleně pro jednotlivé chybějící glify, když je základní písmo nainstalováno, ale neobsahuje požadované znaky.

**Platí náhrada i pro hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Náhrada ovlivňuje všechny objekty prezentace, které používají původní písmo, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se písmo uvnitř vložených OLE objektů (například Excel)?**

Ne. [OLE content](/slides/cs/php-java/manage-ole/) je řízeno vlastní aplikací. Náhrada v prezentaci nepřetváří interní data OLE; může být zobrazena jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit písmo jen v části prezentace (podle snímků nebo oblastí)?**

Cílená náhrada je možná, pokud změníte písmo na úrovni požadovaných objektů/rozsahů místo aplikování globální náhrady na celý dokument. Logika výběru písma během vykreslování zůstává stejná.

**Jak mohu předem zjistit, jaká písma prezentace vůbec používá?**

Použijte [správce písem](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/): poskytuje seznam [rodin v používání](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getfonts/) a informace o [substitucích/„neznámých“ písmech](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getsubstitutions/), což pomáhá naplánovat náhradu.

**Funguje náhrada písma při převodu do PDF/obrázků?**

Ano. Během exportu Aspose.Slides používá stejnou [sekvenci výběru/substituce písma](/slides/cs/php-java/font-selection-sequence/), takže náhrada provedená předem bude při převodu respektována.

**Musím nainstalovat cílové písmo v systému, nebo mohu připojit složku s fonty?**

Instalace není vyžadována: knihovna umožňuje [načítání externích písem](/slides/cs/php-java/custom-font/) ze složek uživatele pro použití během [vykreslování a exportu](/slides/cs/php-java/convert-powerpoint/).

**Opraví náhrada „tofu“ (čtverce) místo znaků?**

Pouze pokud cílové písmo skutečně obsahuje požadované glify. Pokud ne, [nastavte záložní písmo](/slides/cs/php-java/fallback-font/) k pokrytí chybějících znaků.