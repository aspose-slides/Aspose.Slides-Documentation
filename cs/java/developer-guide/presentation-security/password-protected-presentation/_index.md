---
title: Zabezpečení prezentací hesly v Javě
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/java/password-protected-presentation/
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
- zabezpečení PowerPointu
- zabezpečení prezentace
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
description: "Zjistěte, jak snadno zamknout a odemknout heslem chráněné PowerPoint a OpenDocument prezentace pomocí Aspose.Slides pro Javu. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, nastavujete heslo, které vynucuje určitá omezení na prezentaci. Pro odebrání těchto omezení je potřeba zadat heslo. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Obvykle můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úprava**

Pokud chcete, aby pouze určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat prvky v prezentaci, pokud nezadají heslo.  

Nicméně i bez hesla bude uživatel stále schopen dokument otevřít a zobrazit. V režimu jen pro čtení může uživatel prohlížet obsah — včetně hypertextových odkazů, animací, efektů a dalších prvků — ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

Pokud chcete, aby pouze určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec zobrazit obsah prezentace, pokud nezadají heslo.

Technicky omezení otevření také zabraňuje uživatelům v úpravách prezentací — pokud lidé nemohou prezentaci otevřít, nemohou ji ani upravovat.

**Poznámka:** Když heslem chráníte prezentaci tak, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Ochrana heslem v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT — Microsoft PowerPoint Presentation
- ODP — OpenDocument Presentation
- OTP — OpenDocument Presentation Template

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu pro prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úlohy související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Chránit prezentaci heslem**

Můžete prezentaci zašifrovat nastavením hesla. Pak, aby uživatel mohl upravit uzamčenou prezentaci, musí zadat heslo.

Pro zašifrování nebo ochranu heslem prezentace musíte použít metodu `encrypt` (z [IProtectionManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager)) a nastavit heslo pro prezentaci. Heslo předáte metodě `encrypt` a pomocí metody `save` uložíte nyní zašifrovanou prezentaci.

Tento ukázkový kód ukazuje, jak zašifrovat prezentaci:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nastavit ochranu proti zápisu pro prezentaci**

Můžete k prezentaci přidat značku „Do not modify“. Tím uživatelům sdělíte, že nechcete, aby prováděli změny v prezentaci.

**Poznámka:** Proces nastavení ochrany proti zápisu prezentaci nešifruje. Uživatelé — pokud to chtějí — ji mohou upravit, ale pro uložení změn budou muset vytvořit prezentaci pod jiným názvem.

Pro nastavení ochrany proti zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu pro prezentaci:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Načíst šifrovanou prezentaci**

Aspose.Slides umožňuje načíst šifrovanou prezentaci předáním správného hesla prostřednictvím [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/).

Tento ukázkový kód ukazuje, jak načíst šifrovanou prezentaci:

```java
import com.aspose.slides.*;

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

Můžete odstranit šifrování nebo ochranu heslem z prezentace. Tím umožníte uživatelům přístup nebo úpravu prezentace bez omezení.

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#removeEncryption--) . Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

```java
import com.aspose.slides.*;

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

Můžete použít Aspose.Slides k odebrání ochrany proti zápisu použité na souboru prezentace. Tím uživatelé mohou upravovat dle libosti — a neobdrží žádná upozornění při provádění takových úkolů.

Odebrat ochranu proti zápisu z prezentace můžete pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Získat vlastnosti šifrované prezentace**

Obvykle uživatelé mají obtíže získat vlastnosti dokumentu šifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost uživatelům přistupovat k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou i vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides vám to umožní.

Pokud chcete, aby uživatelé nadále mohli přistupovat k vlastnostem šifrované prezentace, předáte `false` metodě [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a přitom poskytnout uživatelům přístup k jejím vlastnostem dokumentu:

```java
import com.aspose.slides.*;

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

Pro zkoumání metadat šifrované prezentace bez načítání snímků nebo jiného obsahu vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/) a předáte `true` metodě [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). V tomto režimu Aspose.Slides ignoruje heslo a načte jen veřejně přístupné vlastnosti dokumentu.

Následující ukázka kódu čte vestavěné i vlastní vlastnosti dokumentu pomocí [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Tento postup funguje pouze tehdy, když byly vlastnosti dokumentu při šifrování ponechány nešifrované (veřejné). Pokud jsou vlastnosti dokumentu zašifrovány, předání `true` metodě `loadOptions.setOnlyLoadDocumentProperties` způsobí výjimku, protože heslo je v tomto režimu ignorováno. Pro přístup k šifrovaným vlastnostem dokumentu nebo načtení kompletní prezentace včetně snímků a dalšího obsahu poskytněte správné heslo prostřednictvím [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace můžete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načítání prezentace chráněné heslem bez zadání hesla.

Tento Java kód ukazuje, jak prozkoumat prezentaci a zjistit, zda je chráněna heslem (bez načítání samotné prezentace):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Zkontrolovat, zda je prezentace šifrována**

Aspose.Slides umožňuje zjistit, zda je prezentace šifrována. K provedení tohoto úkolu můžete použít vlastnost [isEncrypted](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#isEncrypted--) , která vrací `true`, pokud je prezentace šifrována, nebo `false`, pokud šifrována není.

Tento ukázkový kód ukazuje, jak zjistit, zda je prezentace šifrována:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides umožňuje zjistit, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít vlastnost [isWriteProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IProtectionManager#isWriteProtected--) , která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zjistit, zda je prezentace chráněna proti zápisu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ověřit nebo potvrdit, že bylo použito konkrétní heslo**

Možná budete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro ověření hesla.

Tento ukázkový kód ukazuje, jak ověřit heslo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // zkontrolujte, zda se "pass" shoduje s
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Vrací `true`, pokud byla prezentace chráněna proti zápisu uvedeným heslem. V opačném případě vrací `false`.

{{% alert color="info" title="Viz také" %}} 
- [Digital Signature in PowerPoint](/slides/cs/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody podporuje Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení dat vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, která upozorní, že přístup k prezentaci byl odepřen. To pomáhá zabránit neautorizovanému přístupu a chrání obsah prezentace.

**Existují výkonnostní dopady při práci s prezentacemi chráněnými heslem?**

Proces šifrování a dešifrování může během otevírání a ukládání způsobit mírné zatížení. Ve většině případů je tento dopad minimální a výrazně neovlivňuje celkovou dobu zpracování vašich úkolů s prezentacemi.