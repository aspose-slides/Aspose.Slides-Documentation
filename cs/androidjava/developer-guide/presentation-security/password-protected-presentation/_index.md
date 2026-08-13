---
title: Zabezpečení prezentací pomocí hesel na Androidu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Jednoduše uzamkněte a odemkněte prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro Android v Javě. Zabezpečte své prezentace."
---
## **Úvod**

Když prezentaci chráníte heslem, nastavujete heslo, které vynucuje určitá omezení na prezentaci. K odebrání omezení je třeba zadat heslo. Prezentace chráněná heslem je považována za uzamčenou prezentaci.

Typicky můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úprava**

  Pokud chcete, aby pouze určití uživatelé upravovali vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat věci ve vaší prezentaci (pokud nezadají heslo).

  V tomto případě však i bez hesla bude uživatel schopen přistupovat k dokumentu a otevřít jej. V režimu jen pro čtení může uživatel zobrazit obsah nebo prvky – hypertextové odkazy, animace, efekty a další – v prezentaci, ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

  Pokud chcete, aby pouze určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec zobrazit obsah vaší prezentace (pokud nezadají heslo).

  Technicky omezení otevření také zabraňuje uživatelům upravovat vaše prezentace: když lidé nemohou prezentaci otevřít, nemohou ji upravovat ani měnit.

  **Poznámka** že když prezentaci chráníte heslem, aby se zabránilo otevření, soubor prezentace se zašifruje.

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Podporované operace**

Aspose.Slides vám umožňuje použít ochranu heslem na prezentacích k zamezení úprav těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany před zápisem na prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odebrání ochrany před zápisem z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrovaná
- Kontrola, zda je prezentace chráněna heslem.

## **Šifrování prezentace**

Prezentaci můžete zašifrovat nastavením hesla. Pak uživatel, který chce upravit uzamčenou prezentaci, musí zadat heslo.

Pro šifrování nebo ochranu heslem prezentace musíte použít metodu **encrypt** (z rozhraní [IProtectionManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager)) k nastavení hesla pro prezentaci. Heslo předáte metodě **encrypt** a pomocí metody **save** uložíte nyní zašifrovanou prezentaci.

Tento ukázkový kód ukazuje, jak šifrovat prezentaci:

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

## **Nastavení ochrany před zápisem na prezentaci**

Můžete přidat značku „Do not modify“ (Neupravit) k prezentaci. Tímto způsobem můžete uživatelům sdělit, že si nepřejete, aby prováděli změny v prezentaci.

**Poznámka** že proces ochrany před zápisem nešifruje prezentaci. Proto uživatelé – pokud opravdu chtějí – mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit prezentaci pod jiným názvem.

Pro nastavení ochrany před zápisem musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Tento ukázkový kód ukazuje, jak nastavit ochranu před zápisem na prezentaci:

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

## **Načtení zašifrované prezentace**

Aspose.Slides umožňuje načíst zašifrovanou prezentaci předáním správného hesla přes [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/).

Tento ukázkový kód ukazuje, jak otevřít zašifrovanou prezentaci:

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

## **Odstranění šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem na prezentaci. Tímto způsobem budou uživatelé schopni přistupovat k prezentaci nebo ji upravovat bez omezení.

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

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

## **Odstranění ochrany před zápisem z prezentace**

Můžete použít Aspose.Slides k odstranění ochrany před zápisem použité na souboru prezentace. Tímto způsobem mohou uživatelé upravovat dle libosti – a nedostanou žádné varování při provádění takových úkolů.

Odebrat ochranu před zápisem z prezentace můžete pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Tento ukázkový kód ukazuje, jak odstranit ochranu před zápisem z prezentace:

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

## **Získání vlastností zašifrované prezentace**

Typicky uživatelé mají potíže získat vlastnosti dokumentu šifrované nebo heslem chráněné prezentace. Aspose.Slides však nabízí mechanismus, který vám umožní chránit prezentaci heslem a zároveň zachovat možnost uživatelům přistupovat k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou také vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides vám umožní právě to.

Pokud chcete, aby uživatelé i nadále mohli přistupovat k vlastnostem zašifrované prezentace, předávejte `false` metodě [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a zároveň umožnit uživatelům přístup k vlastnostem dokumentu:

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

## **Načíst pouze vlastnosti dokumentu z zašifrované prezentace**

Chcete‑li zkontrolovat metadata zašifrované prezentace, aniž byste načítali snímky nebo další obsah, vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/) a předávejte `true` metodě [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). V tomto režimu Aspose.Slides ignoruje heslo a načte pouze veřejně přístupné vlastnosti dokumentu.

Následující ukázkový kód čte vestavěné i vlastní vlastnosti dokumentu pomocí [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

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

Tento postup funguje pouze tehdy, když byly vlastnosti dokumentu při šifrování ponechány nešifrované (veřejné). Pokud jsou vlastnosti dokumentu zašifrovány, předání `true` metodě `loadOptions.setOnlyLoadDocumentProperties` způsobí výjimku, protože heslo je v tomto režimu ignorováno. Pro přístup k zašifrovaným vlastnostem dokumentu nebo načtení celé prezentace, včetně snímků a dalšího obsahu, zadejte správné heslo pomocí [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Kontrola, zda je prezentace chráněna heslem**

Než načtete prezentaci, můžete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načtení prezentace chráněné heslem bez zadání hesla.

Tento Java kód ukazuje, jak prověřit, zda je prezentace chráněna heslem (bez načítání samotné prezentace):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kontrola, zda je prezentace zašifrována**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace zašifrována. K provedení tohoto úkolu můžete použít vlastnost [isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít vlastnost [isWriteProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ověření nebo potvrzení, že byl použit konkrétní password**

Možná budete chtít ověřit a potvrdit, že byl použit konkrétní password k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro ověření hesla.

Tento ukázkový kód ukazuje, jak ověřit heslo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // zkontrolujte, zda je "pass" shodné s
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Vrací `true`, pokud je prezentace chráněna proti zápisu zadaným heslem. V opačném případě vrací `false`.

{{% alert color="info" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody jsou podporovány v Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň bezpečnosti vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, která upozorňuje, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Má ochrana heslem vliv na výkon při práci s prezentacemi?**

Proces šifrování a dešifrování může při otevírání a ukládání zavést mírné zatížení. Ve většině případů je tento dopad na výkon minimální a významně neovlivňuje celkovou dobu zpracování vašich úkolů s prezentacemi.