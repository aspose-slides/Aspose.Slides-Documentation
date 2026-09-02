---
title: Zabezpečte prezentace pomocí hesel v JavaScriptu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/nodejs-java/password-protected-presentation/
keywords:
- zamknout PowerPoint
- zamknout prezentaci
- odemknout PowerPoint
- odemknout prezentaci
- chránit PowerPoint
- chránit prezentaci
- nastavit heslo
- přidat heslo
- šifrovat PowerPoint
- šifrovat prezentaci
- dešifrovat PowerPoint
- dešifrovat prezentaci
- ochrana proti zápisu
- bezpečnost PowerPointu
- bezpečnost prezentace
- odstranit heslo
- odstranit ochranu
- odstranit šifrování
- zakázat heslo
- zakázat ochranu
- odstranit ochranu proti zápisu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše zamkněte a odemkněte PowerPoint a OpenDocument prezentace chráněné heslem pomocí Aspose.Slides pro Node.js přes Java. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, nastavujete heslo, které vynutí určitá omezení na prezentaci. Pro odebrání omezení je nutné zadat heslo. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Obvykle můžete nastavit heslo, které tato omezení na prezentaci vynutí:

- **Úprava**

  Pokud chcete, aby pouze určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení zabraňuje lidem v úpravách, změnách nebo kopírování obsahu vaší prezentace (pokud neposkytnou heslo).

  Přesto, i bez hesla, uživatel bude moci dokument otevřít. V tomto režimu pouze ke čtení může uživatel prohlížet obsah – hypertextové odkazy, animace, efekty a další – ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

  Pokud chcete, aby pouze určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec prohlížet obsah vaší prezentace (pokud neposkytnou heslo).

  Technicky omezení otevření také zabraňuje úpravám prezentace: když lidé nemohou prezentaci otevřít, nemohou ji měnit.

  **Poznámka** že pokud prezentaci chráníte heslem proti otevření, soubor prezentace se zašifruje.

## **Jak online chránit prezentaci heslem**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Drop or upload your files**.

3. Vyberte soubor, který chcete chránit heslem, ve svém počítači.

4. Zadejte požadované heslo pro ochranu úprav; Zadejte požadované heslo pro ochranu prohlížení.

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte zaškrtávací políčko **Mark as final**.

6. Klikněte na **PROTECT NOW.**

7. Klikněte na **DOWNLOAD NOW.**

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint prezentace
- ODP – OpenDocument prezentace
- OTP – OpenDocument šablona prezentace

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření šifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností šifrované prezentace
- Kontrola, zda je prezentace šifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Šifrování prezentace**

Prezentaci můžete zašifrovat nastavením hesla. Pak uživatel, který chce upravit uzamčenou prezentaci, musí heslo zadat.

Pro šifrování nebo ochranu prezentace heslem musíte použít metodu **encrypt** ze [ProtectionManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager) a nastavit heslo pro prezentaci. Heslo předáte metodě **encrypt** a pomocí metody **save** uložíte nyní zašifrovanou prezentaci.

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Nastavení ochrany proti zápisu na prezentaci**

Můžete přidat značku „Do not modify“ (Neupravovat) do prezentace. Tímto způsobem upozorníte uživatele, že od nich nevyžadujete žádné změny v prezentaci.

**Poznámka** že proces nastavení ochrany proti zápisu nešifruje prezentaci. Proto uživatelé – pokud chtějí – mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit novou prezentaci s jiným názvem.

Pro nastavení ochrany proti zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Dešifrování prezentace; Otevření šifrované prezentace**

Aspose.Slides umožňuje načíst šifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) bez parametrů. Pak budete muset zadat správné heslo pro načtení prezentace.

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // pracovat s odšifrovanou prezentací
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Odstranění šifrování; vypnutí ochrany heslem**

Můžete odstranit šifrování nebo ochranu heslem na prezentaci. Tím se uživatelům umožní přístup nebo úprava prezentace bez omezení.

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Odstranění ochrany proti zápisu z prezentace**

Pomocí Aspose.Slides můžete odstranit ochranu proti zápisu, která byla použita na soubor prezentace. Tím uživatelé mohou upravovat libovolně a nebudou dostávat žádná varování.

Ochranu proti zápisu z prezentace odstraníte pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Získání vlastností šifrované prezentace**

Obvykle uživatelé obtížně získávají vlastnosti dokumentu šifrované nebo heslem chráněné prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost přístupu k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides šifruje prezentaci, jsou také dokumentové vlastnosti prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po zašifrování, Aspose.Slides vám to umožní.

Pokud chcete, aby uživatelé i po zašifrování mohli přistupovat k vlastnostem prezentace, předávejte `false` metodě `setEncryptDocumentProperties` na [ProtectionManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/). Tento ukázkový kód ukazuje, jak šifrovat prezentaci a zároveň umožnit přístup k jejím dokumentovým vlastnostem:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Načíst pouze vlastnosti dokumentu ze šifrované prezentace**

Chcete‑li prozkoumat metadata šifrované prezentace bez načítání snímků a dalšího obsahu, vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/) a předávejte `true` metodě `setOnlyLoadDocumentProperties`. V tomto režimu Aspose.Slides ignoruje heslo a načte pouze veřejně přístupné dokumentové vlastnosti.

Následující příklad kódu čte vestavěné i vlastní dokumentové vlastnosti pomocí `getDocumentProperties` na [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Načíst vestavěné vlastnosti dokumentu.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Načíst vlastní vlastnosti dokumentu.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Tento postup funguje pouze tehdy, když byly dokumentové vlastnosti při šifrování prezentace ponechány nešifrované (veřejné). Pokud jsou dokumentové vlastnosti šifrované, předání `true` metodě `LoadOptions.setOnlyLoadDocumentProperties` vyvolá výjimku, protože v tomto režimu je heslo ignorováno. Pro přístup k šifrovaným vlastnostem nebo načtení celé prezentace včetně snímků a dalšího obsahu poskytněte správné heslo pomocí `LoadOptions.setPassword` na [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/).

## **Kontrola, zda je prezentace chráněna heslem před načtením**

Před načtením prezentace možná budete chtít zkontrolovat, zda není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které vznikají při načítání heslem chráněné prezentace bez zadání hesla.

Tento JavaScriptový kód ukazuje, jak prověřit prezentaci, zda je chráněna heslem (bez samotného načtení prezentace):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kontrola, zda je prezentace šifrována**

Aspose.Slides umožňuje zjistit, zda je prezentace šifrována. K provedení této úlohy můžete použít vlastnost [isEncrypted](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--), která vrací `true`, pokud je prezentace šifrována, nebo `false`, pokud není.

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Aspose.Slides umožňuje zjistit, zda je prezentace chráněna proti zápisu. K provedení této úlohy můžete použít vlastnost [isWriteProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--), která vrací `true`, pokud je prezentace šifrována, nebo `false`, pokud není.

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ověření nebo potvrzení, že konkrétní heslo bylo použito k ochraně prezentace**

Možná budete chtít ověřit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro ověření hesla.

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // zkontrolujte, zda se "pass" shoduje s
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Vrací `true`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrací `false`.

{{% alert color="primary" title="See also" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody jsou v Aspose.Slides podporovány?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení vašich prezentací.

**Co se stane, pokud je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Při zadání nesprávného hesla se vyvolá výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Má práce s prezentacemi chráněnými heslem nějaké dopady na výkon?**

Proces šifrování a dešifrování může při otevírání a ukládání mírně zatížit výkon. Ve většině případů je však dopad minimální a výrazně neovlivní celkovou dobu zpracování vašich úkolů s prezentacemi.