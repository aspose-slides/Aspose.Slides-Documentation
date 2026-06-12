---
title: Zefektivněte nahrazení fontů v prezentacích pomocí JavaScriptu
linktitle: Nahrazení fontu
type: docs
weight: 60
url: /cs/nodejs-java/font-replacement/
keywords:
- font
- nahrazení fontu
- nahrazení fontu
- změna fontu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Bez problémů nahraďte fonty v JavaScriptu pomocí Aspose.Slides pro Node.js prostřednictvím Javy, abyste zajistili konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides umožňuje nahradit jeden font druhým v celé prezentaci. Když je font nahrazen, všechny výskyty původního fontu jsou změněny na nový font.

Pro provedení náhrady fontu načtěte prezentaci, určete zdrojový font a náhradní font, zavolejte metodu pro náhradu fontu a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když záměrně chcete přepnout z jedné skupiny fontů na jinou v celé prezentaci.

## **Nahrazení fontů**

Pokud změníte názor na použití fontu, můžete tento font nahradit jiným. Všechny výskyty starého fontu budou nahrazeny novým fontem.

Aspose.Slides umožňuje nahradit font tímto způsobem:

1. Načtěte příslušnou prezentaci.  
2. Načtěte font, který bude nahrazen.  
3. Načtěte nový font.  
4. Proveďte náhradu fontu.  
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód demonstruje náhradu fontu:

```javascript
// Načte prezentaci
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Načte zdrojový font, který bude nahrazen
    var sourceFont = new aspose.slides.FontData("Arial");
    // Načte nový font
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Nahrazuje fonty
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Uloží prezentaci
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Poznámka" color="warning" %}} 

Pro nastavení pravidel, která určují, co se stane v určitých podmínkách (například pokud není font dostupný), viz [**Náhrada fontů**](/slides/cs/nodejs-java/font-substitution/).

{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi „náhradou fontu“, „nahrazením fontu“ a „záložními fonty“?**

Náhrada je záměrný přechod z jedné rodiny fontů na jinou v celém dokumentu. [Nahrazení](/slides/cs/nodejs-java/font-substitution/) je pravidlo typu „pokud není font dostupný, použij X“. [Záložní font](/slides/cs/nodejs-java/fallback-font/) se uplatňuje selektivně pro jednotlivé chybějící glyfy, když je základní font nainstalován, ale neobsahuje požadované znaky.

**Platí náhrada i pro hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Náhrada ovlivňuje všechny objekty prezentace, které používají původní font, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se font uvnitř vložených OLE objektů (například Excel)?**

Ne. [OLE obsah](/slides/cs/nodejs-java/manage-ole/) je řízen vlastní aplikací. Náhrada v prezentaci nepřetváří interní data OLE; může být zobrazena jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit font jen v části prezentace (podle snímků nebo oblastí)?**

Cílená náhrada je možná, pokud měníte font na úrovni požadovaných objektů/rozsahů místo globální náhrady v celém dokumentu. Logika výběru fontu během vykreslování zůstává stejná.

**Jak mohu předem zjistit, jaké fonty prezentace používá?**

Použijte [správce fontů] (https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/) prezentace: poskytuje seznam [používaných rodin] (https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getfonts/) a informace o [nahrazených/„neznámých“ fontech] (https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), což pomáhá naplánovat náhradu.

**Funguje náhrada fontu při konverzi do PDF/obrázků?**

Ano. Při exportu Aspose.Slides používá stejnou [sekvenci výběru/náhrady fontu](/slides/cs/nodejs-java/font-selection-sequence/), takže náhrada provedená předem bude během konverze zohledněna.

**Musím nainstalovat cílový font do systému, nebo mohu připojit složku s fonty?**

Instalace není vyžadována: knihovna umožňuje [načítání externích fontů](/slides/cs/nodejs-java/custom-font/) z uživatelských složek pro použití během [vykreslování a exportu](/slides/cs/nodejs-java/convert-powerpoint/).

**Opraví náhrada „tofu“ (čtverce) místo znaků?**

Pouze pokud cílový font skutečně obsahuje požadované glyfy. Pokud ne, [nastavte záložní font](/slides/cs/nodejs-java/fallback-font/) pro pokrytí chybějících znaků.