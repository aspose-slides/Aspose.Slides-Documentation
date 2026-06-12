---
title: Zabezpečené prezentace pomocí hesel na Androidu
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
- zašifrovat PowerPoint
- zašifrovat prezentaci
- dešifrovat PowerPoint
- dešifrovat prezentaci
- ochrana proti zápisu
- bezpečnost PowerPoint
- bezpečnost prezentace
- odebrat heslo
- odebrat ochranu
- odebrat šifrování
- zakázat heslo
- zakázat ochranu
- odebrat ochranu proti zápisu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Jednoduše zamkněte a odemkněte heslem chráněné PowerPoint a OpenDocument prezentace pomocí Aspose.Slides pro Android v jazyce Java. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, nastavujete heslo, které vynutí určité omezení na prezentaci. Pro odebrání omezení je třeba zadat heslo. Prezentace chráněná heslem je považována za uzamčenou prezentaci.

Obvykle můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úprava**

  Pokud chcete, aby jen určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení brání lidem v úpravě, změně nebo kopírování věcí ve vaší prezentaci (pokud neposkytnou heslo). 

  Nicméně v tomto případě bude uživatel i bez hesla schopen získat přístup k vašemu dokumentu a otevřít jej. V tomto režimu jen pro čtení může uživatel prohlížet obsah, jako jsou hypertextové odkazy, animace, efekty a další, ve vaší prezentaci, ale nemůže kopírovat položky ani uložit prezentaci. 

- **Otevření**

  Pokud chcete, aby jen určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení brání lidem dokonce v prohlížení obsahu vaší prezentace (pokud neposkytnou heslo).

  Technicky omezení otevření také zabraňuje uživatelům upravovat vaše prezentace: když lidé nemohou prezentaci otevřít, nemohou ji upravovat ani měnit. 
  
  **Poznámka** že když chráníte prezentaci heslem, aby se zabránilo otevření, soubor prezentace se stane šifrovaným.

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Supported formats**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech: 

- PPTX a PPT – Microsoft PowerPoint prezentace 
- ODP – OpenDocument prezentace 
- OTP – OpenDocument šablona prezentace 

**Supported operations**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích k zamezení úprav těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu pro prezentaci

**Other operations**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření šifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností šifrované prezentace
- Kontrola, zda je prezentace šifrovaná
- Kontrola, zda je prezentace chráněna heslem.

## **Zašifrovat prezentaci**

Můžete prezentaci zašifrovat nastavením hesla. Pak, aby mohl uživatel upravit uzamčenou prezentaci, musí zadat heslo. 

Pro zašifrování nebo ochranu prezentace heslem musíte použít metodu encrypt (z [IProtectionManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager)) k nastavení hesla pro prezentaci. Heslo předáte metodě encrypt a použijete metodu save k uložení nyní zašifrované prezentace.

Ukázkový kód vám ukazuje, jak zašifrovat prezentaci:

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

Můžete do prezentace přidat značku „Neupravit“. Tím můžete uživatelům sdělit, že nechcete, aby prováděli změny v prezentaci.  

**Poznámka** že proces ochrany proti zápisu prezentaci nešifruje. Proto uživatelé — pokud skutečně chtějí — mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit prezentaci pod jiným názvem. 

Pro nastavení ochrany proti zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Tento ukázkový kód vám ukazuje, jak nastavit ochranu proti zápisu pro prezentaci:

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

Aspose.Slides vám umožňuje načíst šifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) bez parametrů. Poté budete muset zadat správné heslo pro načtení prezentace.

Ukázkový kód vám ukazuje, jak dešifrovat prezentaci: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // pracovat s dešifrovanou prezentací
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Odstranit šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace. Tím se uživatelům umožní přístup k prezentaci nebo její úpravy bez omezení. 

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeEncryption-). Tento ukázkový kód vám ukazuje, jak odstranit šifrování z prezentace:

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

Můžete použít Aspose.Slides k odstranění ochrany proti zápisu u souboru prezentace. Tím uživatelé mohou upravovat dle libosti — a nedostanou žádná varování při provádění takových úkolů.

Ochranu proti zápisu z prezentace můžete odstranit pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection-). Tento ukázkový kód vám ukazuje, jak odstranit ochranu proti zápisu z prezentace:

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

Obvykle mají uživatelé potíže získat vlastnosti dokumentu šifrované nebo heslem chráněné prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost pro uživatele získat vlastnosti této prezentace.

**Poznámka** že když Aspose.Slides šifruje prezentaci, vlastnosti dokumentu prezentace jsou také ve výchozím nastavení chráněny heslem. Pokud však potřebujete, aby vlastnosti prezentace byly přístupné (i po zašifrování prezentace), Aspose.Slides vám to umožňuje. 

Pokud chcete, aby uživatelé i nadále mohli přistupovat k vlastnostem prezentace, kterou jste zašifrovali, můžete nastavit vlastnost [encryptDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) na `true`. Tento ukázkový kód vám ukazuje, jak zašifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem dokumentu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace možná budete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načítání prezentace chráněné heslem bez zadání hesla.

Tento Java kód vám ukazuje, jak prověřit prezentaci, zda je chráněna heslem (bez načtení samotné prezentace):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Zkontrolovat, zda je prezentace šifrována**

Aspose.Slides vám umožňuje zjistit, zda je prezentace šifrována. K provedení tohoto úkolu můžete použít vlastnost [isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#isEncrypted-), která vrací `true`, pokud je prezentace šifrována, nebo `false`, pokud není.

Ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace šifrována:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zjistit, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít vlastnost [isWriteProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected-), která vrací `true`, pokud je prezentace šifrována, nebo `false`, pokud není šifrována.

Ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ověřit nebo potvrdit, že bylo použito konkrétní heslo**

Možná budete chtít zkontrolovat a potvrdit, že bylo použito konkrétní heslo k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky k ověření hesla. 

Ukázkový kód vám ukazuje, jak ověřit heslo:

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

{{% alert color="primary" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaké šifrovací metody jsou podporovány v Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení vašich prezentací.

**Co se stane, pokud je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Při použití nesprávného hesla se vyvolá výjimka, která vás upozorní, že přístup k prezentaci byl odepřen. To pomáhá předcházet neoprávněnému přístupu a chrání obsah prezentace.

**Mají práce s prezentacemi chráněnými heslem nějaké dopady na výkon?**

Proces šifrování a dešifrování může během operací otevírání a ukládání způsobit mírné zatížení. Ve většině případů je tento dopad na výkon minimální a významně neovlivňuje celkový čas zpracování vašich úkolů s prezentacemi.