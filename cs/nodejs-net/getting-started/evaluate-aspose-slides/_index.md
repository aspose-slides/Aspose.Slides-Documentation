---
title: Vyhodnocení Aspose.Slides
type: docs
weight: 120
url: /cs/nodejs-net/evaluate-aspose-slides/
keywords:
- vyhodnocení Aspose.Slides
- evaluační verze
- evaluační vodoznak
- omezení zkušební verze
- dočasná licence
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Co omezuje evaluační verze Aspose.Slides pro Node.js přes .NET, včetně skriptu, který ukazuje obě omezení a jak je odstranit pomocí licence."
---
## **Přehled**

Zkušební verze Aspose.Slides pro Node.js přes .NET je stejný npm balíček jako licencovaná verze. Bez licence běží v evaluačním režimu: všechny funkce fungují, ale uložené prezentace a většina exportů obsahuje vodoznak a text, který váš kód načte zpět, je zkrácen. Tento článek popisuje obě omezení a ukazuje, jak je odstranit.

## **Omezení zkušební verze**

**Zkušební vodoznak na každém snímku.** Když uložíte prezentaci bez licence, Aspose.Slides přidá textové pole doprostřed každého snímku uloženého souboru. Textové pole je uzamčeno a zobrazuje „Evaluation only.“ následované řádkem s názvem produktu a řádkem s copyrightem. Vodoznak je uložen do souboru, nikoli do prezentace v paměti, a otevření prezentace jej nepřidá. Soubor, který byl uložen v evaluačním režimu, již textové pole obsahuje, takže jeho opětovné otevření a uložení přidá druhý vodoznak na každý snímek.

Stejný vodoznak je vykreslen také při exportu do PDF, XPS nebo HTML nebo při renderování snímků jako obrázků. Pokud renderujete prezentaci, která byla již dříve uložena v evaluačním režimu, obrázek zobrazí jak uložený vodoznak, tak ten renderovaný.

**Zkrácený text, když ho váš kód načte.** Text, který váš kód načte pomocí vlastnosti `text` textového rámce, odstavce nebo úseku, je oříznut na prvních pět znaků, následované upozorněním "... text byl zkrácen kvůli omezení evaluační verze." Text s pěti a méně znaky je vrácen celý. Toto platí pro každý snímek a dokonce i pro text, který váš kód právě přiřadil. Exporty do Markdownu a HTML5 jsou zkráceny stejným způsobem.

Text, který váš kód zapíše, je uložen celý: soubory PPTX, stránky PDF a obrázky snímků obsahují kompletní text.

## **Zobrazte omezení ve skriptu**

Následující skript ukazuje obě omezení. Předpokládá, že jste nainstalovali balíček podle [Instalace](/slides/cs/nodejs-net/installation/) a že jej spouštíte ze složky projektu. Přidá obdélník s větou na první snímek, načte větu zpět, uloží prezentaci jako `evaluation.pptx` a poté znovu otevře soubor a spočítá tvary na snímku.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Bez licence jsou vráceny pouze prvních pět znaků.
    console.log("Text read back:", rectangle.textFrame.text);

    // Ukládání přidá evaluační vodoznak na každý snímek souboru.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // Snímek nyní obsahuje obdélník a textové pole vodoznaku.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Bez licence skript vypíše:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

Druhý tvar je textové pole vodoznaku. Otevřete `evaluation.pptx` a uvidíte celou větu v obdélníku a vodoznak uprostřed snímku.

## **Odstranění omezení**

Pro odstranění obou omezení použijte licenci před vytvořením jakéhokoli objektu `Presentation`. [Licencování](/slides/cs/nodejs-net/licensing/) ukazuje, jak použít licenční soubor.

{{% alert color="success" title="Tip" %}}
Pro otestování Aspose.Slides bez evaluačních omezení před zakoupením požádejte o bezplatnou **30denní dočasnou licenci**. Podrobnosti najdete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Často kladené otázky**

**Omezuje evaluační režim počet snímků?**

Ne. Prezentace jsou vytvářeny, otevírány a ukládány se všemi svými snímky. Vodoznak a zkrácení textu se vztahují na každý snímek stejně.

**Proč mé exportované obrázky snímků zobrazují vodoznak dvakrát?**

Prezentace byla uložena v evaluačním režimu před tím, než jste ji renderovali, takže již obsahuje textové pole vodoznaku, a renderování bez licence nakreslí další vodoznak navíc.

**Mohu ověřit, že můj kód produkuje správný text v evaluačním režimu?**

Ano. Otevřete uložený soubor nebo exportované PDF: obsahují celý text. Pouze text, který váš kód načte zpět, a výstup do Markdownu nebo HTML5 je zkrácen.