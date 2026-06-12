---
title: Zabezpečené prezentace pomocí hesel v JavaScriptu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/nodejs-java/password-protected-presentation/
keywords:
- uzamknout PowerPoint
- uzamknout prezentaci
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
- bezpečnost PowerPoint
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
description: "Jednoduše uzamkněte a odemkněte prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro Node.js v Javě. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, znamená to, že nastavujete heslo, které vynutí určitá omezení na prezentaci. Pro odstranění omezení je třeba zadat heslo. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Obvykle můžete nastavit heslo k vynucení těchto omezení na prezentaci:

- **Úprava**

  Pokud chcete, aby jen určití uživatelé upravovali vaši prezentaci, můžete nastavit omezení úpravy. Omezení zde zabraňuje lidem upravovat, měnit nebo kopírovat obsah vaší prezentace (pokud neposkytnou heslo).

  Nicméně i bez hesla bude uživatel schopen dokument otevřít. V režimu jen pro čtení může uživatel zobrazit obsah – hypertextové odkazy, animace, efekty a další – ale nemůže položky kopírovat ani prezentaci uložit.

- **Otevření**

  Pokud chcete, aby jen určití uživatelé otevřeli vaši prezentaci, můžete nastavit omezení otevření. Omezení zde zabraňuje lidem vůbec zobrazit obsah vaší prezentace (pokud neposkytnou heslo).

  Technicky omezení otevření také brání uživatelům v úpravách: pokud lidé nemohou prezentaci otevřít, nemohou ji měnit.

  **Poznámka** že když chráníte prezentaci heslem, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Jak chránit prezentaci heslem online**

1. Navštivte naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Přetáhněte nebo nahrajte soubory**.

3. Vyberte soubor, který chcete chránit heslem, ve svém počítači.

4. Zadejte požadované heslo pro ochranu úprav; Zadejte požadované heslo pro ochranu prohlížení.

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Mark as final**.

6. Klikněte na **PROTECT NOW.**

7. Klikněte na **DOWNLOAD NOW.**

## **Ochrana heslem prezentací v Aspose.Slides**
**Supported formats**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Prezentace
- OTP – OpenDocument Šablona prezentace

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám následujícími způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním tímto způsobem:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Šifrování prezentace**

Prezentaci můžete zašifrovat nastavením hesla. Pak, aby mohl uživatel upravit uzamčenou prezentaci, musí zadat heslo.

Pro šifrování nebo ochranu prezentace heslem musíte použít metodu encrypt (z [ProtectionManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager)) ke nastavení hesla pro prezentaci. Heslo předáte metodě encrypt a použijete metodu save k uložení nyní zašifrované prezentace.

Tento ukázkový kód vám ukazuje, jak šifrovat prezentaci:

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

Můžete do prezentace přidat značku s textem “Do not modify”. Tím informujete uživatele, že nechcete, aby prováděli změny v prezentaci.

**Poznámka** že proces ochrany proti zápisu nešifruje prezentaci. Proto uživatelé—pokud chtějí—mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit prezentaci pod jiným názvem.

Pro nastavení ochrany proti zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Tento ukázkový kód vám ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

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

## **Dešifrování prezentace; otevření zašifrované prezentace**

Aspose.Slides umožňuje načíst zašifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) bez parametrů. Pak budete muset zadat správné heslo pro načtení prezentace.

Tento ukázkový kód vám ukazuje, jak dešifrovat prezentaci:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // pracovat s dešifrovanou prezentací
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Odstranění šifrování; vypnutí ochrany heslem**

Můžete odstranit šifrování nebo ochranu heslem u prezentace. Tím uživatelé získají možnost přistupovat k prezentaci nebo ji upravovat bez omezení.

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Tento ukázkový kód vám ukazuje, jak odstranit šifrování z prezentace:

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

Pomocí Aspose.Slides můžete odstranit ochranu proti zápisu použitou na souboru prezentace. Tím uživatelé mohou upravovat dle libosti — a nedostanou žádná varování při provádění takových úkolů.

Můžete odstranit ochranu proti zápisu z prezentace pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Tento ukázkový kód vám ukazuje, jak odstranit ochranu proti zápisu z prezentace:

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

## **Získání vlastností zašifrované prezentace**

Obvykle mají uživatelé potíže se získáním vlastností dokumentu zašifrované nebo heslem chráněné prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost, aby uživatelé mohli přistupovat k vlastnostem této prezentace.

**Poznámka** že když Aspose.Slides šifruje prezentaci, její vlastnosti dokumentu jsou také ve výchozím nastavení chráněny heslem. Pokud však potřebujete, aby byly vlastnosti prezentace přístupné (i po zašifrování prezentace), Aspose.Slides vám to umožní.

Pokud chcete, aby uživatelé zachovali možnost přístupu k vlastnostem prezentace, kterou jste zašifrovali, můžete nastavit vlastnost [encryptDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) na `true`. Tento ukázkový kód vám ukazuje, jak šifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem dokumentu:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kontrola, zda je prezentace chráněna heslem před načtením**

Před načtením prezentace můžete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které vznikají při načtení prezentace chráněné heslem bez zadání hesla.

Tento JavaScriptový kód vám ukazuje, jak prověřit prezentaci, zda je chráněna heslem (bez načtení samotné prezentace):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kontrola, zda je prezentace zašifrována**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace zašifrována. K provedení tohoto úkolu můžete použít vlastnost [isEncrypted](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) , která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

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

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít vlastnost [isWriteProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) , která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

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

## **Ověření nebo potvrzení, že byl použit konkrétní heslo k ochraně prezentace**

Můžete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro ověření hesla.

Tento ukázkový kód vám ukazuje, jak ověřit heslo:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // zkontrolovat, zda se "pass" shoduje s
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Vrací `true`, pokud byla prezentace šifrována zadaným heslem. V opačném případě vrací `false`.

{{% alert color="primary" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Při použití nesprávného hesla je vyvolána výjimka, která vás upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Jaké šifrovací metody jsou v Aspose.Slides podporovány?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení vašich prezentací.

**Má práce s prezentacemi chráněnými heslem nějaké dopady na výkon?**

Šifrovací a dešifrovací proces může během operací otevření a ukládání zavést mírné zatížení. Ve většině případů je tento dopad na výkon nepatrný a významně neovlivňuje celkovou dobu zpracování úkolů souvisejících s prezentacemi.