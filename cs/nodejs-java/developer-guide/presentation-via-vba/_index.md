---
title: Správa VBA projektů v prezentacích pomocí JavaScriptu
linktitle: Prezentace přes VBA
type: docs
weight: 250
url: /cs/nodejs-java/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- přidat makro
- odstranit makro
- extrahovat makro
- přidat VBA
- odstranit VBA
- extrahovat VBA
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Generujte a upravujte prezentace PowerPoint a OpenDocument pomocí VBA v JavaScriptu s Aspose.Slides pro Node.js přes Java, abyste zefektivnili svůj pracovní postup."
---
## **Úvod**

Aspose.Slides poskytuje třídy pro práci s makry a kódem VBA.

{{% alert title="Note" color="warning" %}} 

Pokud při převodu prezentace obsahující makra do jiného formátu souboru (PDF, HTML, atd.) Aspose.Slides ignoruje všechna makra (makra nejsou přenesena do výsledného souboru).

Když přidáte makra do prezentace nebo znovu uložíte prezentaci obsahující makra, Aspose.Slides jednoduše zapíše bajty makr.

Aspose.Slides **nikdy** nespouští makra v prezentaci.

{{% /alert %}}

## **Přidání VBA maker**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/vbaproject/) , která vám umožní vytvářet VBA projekty (a odkazy na projekty) a upravovat existující moduly. Můžete použít třídu [VbaProject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/vbaproject/) k správě VBA vloženého v prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) .
2. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/vbaproject/#VbaProject--) k přidání nového VBA projektu.
3. Přidejte modul do VbaProject.
4. Nastavte zdrojový kód modulu.
5. Přidejte odkazy na <stdole>.
6. Přidejte odkazy na **Microsoft Office**.
7. Propojte odkazy s VBA projektem.
8. Uložte prezentaci.

Tento JavaScriptový kód ukazuje, jak od začátku přidat VBA makro do prezentace:

```javascript
// Vytvoří instanci třídy prezentace
let pres = new aspose.slides.Presentation();
try {
    // Vytvoří nový VBA projekt
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Přidá prázdný modul do VBA projektu
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Nastaví zdrojový kód modulu
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Vytvoří odkaz na <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Vytvoří odkaz na Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Přidá odkazy do VBA projektu
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Uloží prezentaci
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Možná budete chtít vyzkoušet **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), což je bezplatná webová aplikace sloužící k odstranění maker z dokumentů PowerPoint, Excel a Word. 

{{% /alert %}} 

## **Odstranění VBA maker**

Pomocí vlastnosti [VbaProject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getVbaProject--) třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) můžete odstranit VBA makro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci obsahující makro.
2. Získejte přístup k modulu Macro a odstraňte jej.
3. Uložte upravenou prezentaci.

Tento JavaScriptový kód ukazuje, jak odstranit VBA makro:

```javascript
// Načte prezentaci obsahující makro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Přistoupí k modulu Vba a odebere jej
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Uloží prezentaci
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Extrahování VBA maker**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje VBA projekt.
3. Procházejte všechny moduly obsažené ve VBA projektu a zobrazte makra.

Tento JavaScriptový kód ukazuje, jak extrahovat VBA makra z prezentace obsahující makra:

```javascript
// Načte prezentaci obsahující makro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Zkontroluje, zda prezentace obsahuje VBA projekt
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kontrola, zda je VBA projekt chráněn heslem**

Pomocí metody [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA projekt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/vbaproject/).
3. Zkontrolujte, zda je VBA projekt chráněn heslem, abyste mohli zobrazit jeho vlastnosti.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Zkontrolujte, zda prezentace obsahuje VBA projekt.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Co se stane s makry, pokud uložíme prezentaci jako PPTX?**

Makra budou odstraněna, protože PPTX nepodporuje VBA. Pro zachování maker zvolte PPTM, PPSM nebo POTM.

**Může Aspose.Slides spouštět makra v prezentaci, například pro aktualizaci dat?**

Ne. Knihovna nikdy nespouští VBA kód; spuštění je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

**Je podporována práce s ActiveX ovladači propojenými s VBA kódem?**

Ano, můžete přistupovat k existujícím [ActiveX ovladačům](/slides/cs/nodejs-java/activex/), upravovat jejich vlastnosti a odstraňovat je. To je užitečné, když makra interagují s ActiveX.