---
title: Zabezpečte prezentace pomocí hesel na Androidu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Jednoduše zamkněte a odemkněte heslem chráněné prezentace PowerPoint i OpenDocument pomocí Aspose.Slides pro Android v Javě. Zabezpečte své prezentace."
---
## **Úvod**

Když prezentaci chráníte heslem, nastavujete heslo, které vynutí určitá omezení na prezentaci. Pro odstranění omezení je třeba zadat heslo. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Obvykle můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úpravy**

  Pokud chcete, aby pouze určité uživatele mohli upravovat vaši prezentaci, můžete nastavit omezení úprav. Toto omezení zabraňuje lidem v úpravě, změně nebo kopírování obsahu vaší prezentace (pokud neposkytnou heslo).

  Přestože v tomto případě uživatel bez hesla může dokument otevřít, v režimu jen pro čtení může prohlížet obsah – odkazy, animace, efekty a další – ale nemůže kopírovat položky ani uložit prezentaci.

- **Otevření**

  Pokud chcete, aby pouze určité uživatele mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec prohlížet obsah prezentace (pokud neposkytnou heslo).

  Technicky omezení otevření také zabraňuje uživatelům v úpravách prezentací: když lidé nemohou prezentaci otevřít, nemohou ji ani měnit.

  **Poznámka** že když chráníte prezentaci heslem, aby se zabránilo otevření, soubor prezentace se zašifruje.

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Podporované operace**

Aspose.Slides vám umožňuje použít ochranu heslem na prezentacích k zamezení úprav těmito způsoby:

- Zašifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides vám umožňuje provádět další úkoly týkající se ochrany heslem a šifrování těmito způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odebrání šifrování; deaktivace ochrany heslem
- Odebrání ochrany proti zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrovaná
- Kontrola, zda je prezentace chráněna heslem.

## **Zašifrovat prezentaci**

Můžete zašifrovat prezentaci nastavením hesla. Pak uživatel, který chce upravit uzamčenou prezentaci, musí zadat heslo.

Pro zašifrování nebo ochranu heslem prezentace musíte použít metodu encrypt (z [IProtectionManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager)) a nastavit heslo pro prezentaci. Heslo předáte metodě encrypt a pomocí metody save uložíte nyní zašifrovanou prezentaci.

Tento ukázkový kód ukazuje, jak zašifrovat prezentaci:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nastavit ochranu proti zápisu na prezentaci**

Můžete přidat označení „Neupravit“ k prezentaci. Tímto způsobem uživatelům sdělíte, že nechcete, aby prováděli změny v prezentaci.

**Poznámka** že proces ochrany proti zápisu nešifruje prezentaci. Uživatelé – pokud to chtějí – mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit soubor s jiným názvem.

Pro nastavení ochrany proti zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Načíst zašifrovanou prezentaci**

Aspose.Slides umožňuje načíst zašifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) bez parametrů. Poté budete muset zadat správné heslo pro načtení prezentace.

Tento ukázkový kód ukazuje, jak dešifrovat prezentaci:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // práce s dešifrovanou prezentací
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Odebrat šifrování z prezentace**

Můžete odebrat šifrování nebo ochranu heslem z prezentace. Tímto způsobem budou uživatelé schopni přistupovat k prezentaci nebo ji upravovat bez omezení.

Pro odebrání šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--). Tento ukázkový kód ukazuje, jak odebrat šifrování z prezentace:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Odebrat ochranu proti zápisu z prezentace**

Můžete použít Aspose.Slides k odebrání ochrany proti zápisu použité na souboru prezentace. Tímto způsobem uživatelé mohou upravovat dle libosti a nebudou dostávat žádná varování při provádění takových úkolů.

Můžete odebrat ochranu proti zápisu z prezentace pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--). Tento ukázkový kód ukazuje, jak odebrat ochranu proti zápisu z prezentace:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Získat vlastnosti zašifrované prezentace**

Obvykle uživatelé mají potíže získat vlastnosti dokumentu zašifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a současně zachovat možnost uživatelům přistupovat k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou také vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides to umožňuje.

Pokud chcete, aby uživatelé i nadále mohli přistupovat k vlastnostem zašifrované prezentace, předávejte `false` metodě [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem dokumentu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Načíst jen vlastnosti dokumentu ze zašifrované prezentace**

Pro zkoumání metadat zašifrované prezentace bez načítání snímků nebo jiného obsahu vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/) a předávejte `true` metodě [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). V tomto režimu Aspose.Slides ignoruje heslo a načte jen veřejně přístupné vlastnosti dokumentu.

Následující příklad kódu čte vestavěné i vlastní vlastnosti dokumentu pomocí [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Načíst vestavěné vlastnosti dokumentu.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Načíst vlastní vlastnosti dokumentu.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Tento postup funguje pouze tehdy, když byly vlastnosti dokumentu při šifrování ponechány nešifrované (veřejné). Pokud jsou vlastnosti dokumentu šifrované, předání `true` metodě `loadOptions.setOnlyLoadDocumentProperties` způsobí výjimku, protože v tomto režimu je heslo ignorováno. Pro přístup k zašifrovaným vlastnostem dokumentu nebo načtení kompletní prezentace včetně snímků a dalšího obsahu poskytněte správné heslo pomocí [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace možná budete chtít ověřit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, ke kterým dochází, když se načte prezentace chráněná heslem bez zadání hesla.

Tento Java kód ukazuje, jak zkontrolovat, zda je prezentace chráněna heslem (bez načítání samotné prezentace):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Zkontrolovat, zda je prezentace zašifrována**

Aspose.Slides umožňuje zjistit, zda je prezentace zašifrována. K provedení této úlohy můžete použít vlastnost [isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides umožňuje zjistit, zda je prezentace chráněna proti zápisu. K provedení této úlohy můžete použít vlastnost [isWriteProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--), která vrací `true`, pokud je prezentace chráněna, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ověřit nebo potvrdit, že bylo použito konkrétní heslo**

Možná budete chtít ověřit, že byl k ochraně dokumentu prezentace použit konkrétní heslo. Aspose.Slides poskytuje prostředky pro validaci hesla.

Tento ukázkový kód ukazuje, jak validovat heslo:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // zkontrolovat, zda se "pass" shoduje s
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Vrací `true`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrací `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/cs/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody Aspose.Slides podporuje?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení vašich dat v prezentacích.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Vyvolá se výjimka, která upozorní, že přístup k prezentaci byl odmítnut. Tím se zabraňuje neoprávněnému přístupu a chrání obsah prezentace.

**Má práce s prezentacemi chráněnými heslem nějaký dopad na výkon?**

Proces šifrování a dešifrování může během otevírání a ukládání způsobit mírné zatížení. Ve většině případů je však dopad na výkon minimální a výrazně neovlivní celkový čas zpracování vašich úkolů s prezentacemi.