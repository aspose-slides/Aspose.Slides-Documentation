---
title: Zabezpečené prezentace pomocí hesel v Javě
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/java/password-protected-presentation/
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
- Java
- Aspose.Slides
description: "Zjistěte, jak snadno zamknout a odemknout heslem chráněné prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro Java. Zabezpečte své prezentace."
---
## **Úvod**

Když prezentaci chráníte heslem, nastavujete heslo, které uplatňuje určitá omezení na prezentaci. Pro odstranění těchto omezení je nutné zadat heslo. Prezentace chráněná heslem se považuje za zamčenou prezentaci.

Obvykle můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úprava**

Pokud chcete, aby pouze určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat prvky ve vaší prezentaci, pokud neposkytnou heslo.  
Nicméně i bez hesla bude uživatel stále schopen přistupovat k vašemu dokumentu a otevřít jej. V tomto režimu jen pro čtení může uživatel zobrazit obsah — včetně hypertextových odkazů, animací, efektů a dalších prvků — ve vaší prezentaci, ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

Pokud chcete, aby pouze určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec zobrazit obsah vaší prezentace, pokud neposkytnou heslo.  
Technicky toto omezení otevření také zabraňuje uživatelům upravovat vaše prezentace — pokud lidé nemohou otevřít prezentaci, nemohou ji upravovat ani provádět změny.

**Poznámka:** Když chráníte prezentaci heslem, aby se zabránilo jejímu otevření, soubor prezentace se šifruje.

## **Ochrana heslem v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v následujících formátech:

- PPTX a PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Podporované operace**

Aspose.Slides vám umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám následujícími způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu pro prezentaci

**Další operace**

Aspose.Slides vám umožňuje provádět další úkoly související s ochranou heslem a šifrováním následujícími způsoby:

- Dešifrování prezentace; otevření šifrované prezentace
- Odstranění šifrování; deaktivace ochrany heslem
- Odebrání ochrany proti zápisu z prezentace
- Získání vlastností šifrované prezentace
- Kontrola, zda je prezentace šifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Chránit prezentaci heslem**

Můžete šifrovat prezentaci nastavením hesla. Pak, aby uživatel mohl upravit zamčenou prezentaci, musí zadat heslo.  

Pro šifrování nebo ochranu prezentace heslem musíte použít metodu encrypt (z [IProtectionManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager)), která nastaví heslo pro prezentaci. Heslo předáte metodě encrypt a použijete metodu save k uložení nyní šifrované prezentace.  

Tento ukázkový kód ukazuje, jak šifrovat prezentaci:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nastavit ochranu proti zápisu pro prezentaci**

Můžete k prezentaci přidat značku s textem „Neupravit“. Tímto způsobem můžete uživatelům sdělit, že si nepřejete, aby prováděli změny v prezentaci.  

**Poznámka** že proces ochrany proti zápisu nešifruje prezentaci. Proto uživatelé — pokud skutečně chtějí — mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit prezentaci pod jiným názvem.  

Pro nastavení ochrany proti zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu pro prezentaci:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Načíst šifrovanou prezentaci**

Aspose.Slides vám umožňuje načíst šifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#removeEncryption--) bez parametrů. Poté budete muset zadat správné heslo pro načtení prezentace.  

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

## **Odstranit šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace. Tímto způsobem budou uživatelé moci přistupovat k prezentaci nebo ji upravovat bez omezení.  

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#removeEncryption--). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

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

## **Odstranit ochranu proti zápisu z prezentace**

Můžete pomocí Aspose.Slides odstranit ochranu proti zápisu použité na souboru prezentace. Tímto způsobem mohou uživatelé upravovat dle libosti — a neobdrží žádná varování při provádění takových úkolů.  

Ochranu proti zápisu z prezentace můžete odstranit pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#removeWriteProtection--). Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Získat vlastnosti šifrované prezentace**

Obvykle uživatelé mají potíže získat vlastnosti dokumentu šifrované nebo heslem chráněné prezentace. Nicméně Aspose.Slides nabízí mechanismus, který umožňuje chránit prezentaci heslem a přitom zachovat možnost uživatelům přistupovat k jejím vlastnostem.  

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides šifruje prezentaci, jsou také vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides vám to umožní.  

Pokud chcete, aby uživatelé zachovali možnost přistupovat k vlastnostem šifrované prezentace, předávejte `false` metodě [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Tento ukázkový kód ukazuje, jak šifrovat prezentaci a přitom uživatelům poskytnout přístup k jejím vlastnostem dokumentu:

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

## **Načíst pouze vlastnosti dokumentu ze šifrované prezentace**

Pro prohlédnutí metadat šifrované prezentace bez načítání jejích snímků či jiného obsahu vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/) a předávejte `true` metodě [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). V tomto režimu Aspose.Slides ignoruje heslo a načte pouze veřejně přístupné vlastnosti dokumentu.  

Následující příklad kódu čte vestavěné a vlastní vlastnosti dokumentu pomocí [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Tento postup funguje pouze tehdy, když byly vlastnosti dokumentu při šifrování prezentace ponechány nezašifrované (veřejné). Pokud jsou vlastnosti dokumentu zašifrovány, předání `true` metodě `loadOptions.setOnlyLoadDocumentProperties` způsobí výjimku, protože heslo je v tomto režimu ignorováno. Pro přístup k zašifrovaným vlastnostem dokumentu nebo načtení kompletní prezentace, včetně jejích snímků a jiného obsahu, zadejte správné heslo pomocí [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace možná budete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tímto způsobem se vyhnete chybám a podobným problémům, které se objeví při načtení prezentace chráněné heslem bez zadání hesla.  

Tento Java kód ukazuje, jak zkontrolovat prezentaci, zda je chráněna heslem (bez načtení samotné prezentace):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Zkontrolovat, zda je prezentace šifrována**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace šifrována. K provedení tohoto úkolu můžete použít vlastnost [isEncrypted](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#isEncrypted--) , která vrací `true`, pokud je prezentace šifrována, nebo `false`, pokud šifrována není.  

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace šifrována:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít vlastnost [isWriteProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#isWriteProtected--) , která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není.  

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

Možná budete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky k ověření hesla.  

Tento ukázkový kód ukazuje, jak ověřit heslo:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // zkontrolujte, zda se "pass" shoduje s
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Vrátí `true`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrátí `false`.

{{% alert color="primary" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody Aspose.Slides podporuje?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň bezpečnosti dat vašich prezentací.

**Co se stane, pokud je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, pokud je použito nesprávné heslo, což vás upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Má práce s prezentacemi chráněnými heslem vliv na výkon?**

Proces šifrování a dešifrování může během operací otevírání a ukládání způsobit mírné zatížení. Ve většině případů je tento dopad na výkon minimální a významně neovlivňuje celkovou dobu zpracování vašich úkolů s prezentacemi.