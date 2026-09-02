---
title: "Zabezpečte prezentace hesly v .NET"
linktitle: "Ochrana heslem"
type: docs
weight: 20
url: /cs/net/password-protected-presentation/
keywords:
- "uzamknout PowerPoint"
- "uzamknout prezentaci"
- "odemknout PowerPoint"
- "odemknout prezentaci"
- "chránit PowerPoint"
- "chránit prezentaci"
- "nastavit heslo"
- "přidat heslo"
- "zašifrovat PowerPoint"
- "zašifrovat prezentaci"
- "dešifrovat PowerPoint"
- "dešifrovat prezentaci"
- "ochrana proti zápisu"
- "bezpečnost PowerPoint"
- "bezpečnost prezentace"
- "odebrat heslo"
- "odebrat ochranu"
- "odebrat šifrování"
- "zakázat heslo"
- "zakázat ochranu"
- "odebrat ochranu proti zápisu"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Zjistěte, jak snadno uzamknout a odemknout prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro .NET. Zabezpečte své prezentace."
---
## **Úvod**

Když prezentaci chráníte heslem, znamená to, že nastavujete heslo, které vynucuje určitá omezení na prezentaci. Pro odstranění těchto omezení je nutné zadat heslo. Prezentace chráněná heslem je považována za uzamčenou prezentaci.

Obvykle můžete nastavit heslo k vynucení těchto omezení na prezentaci:

- **Modification**

Pokud chcete, aby jen určití uživatelé upravovali vaši prezentaci, můžete nastavit omezení úprav. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat prvky ve vaší prezentaci, pokud neposkytnou heslo. Nicméně i bez hesla bude uživatel stále schopen přistupovat k vašemu dokumentu a otevřít jej. V tomto režimu jen pro čtení může uživatel zobrazit obsah — včetně hypertextových odkazů, animací, efektů a dalších prvků — ve vaší prezentaci, ale nemůže kopírovat položky ani prezentaci uložit. 

- **Opening**

Pokud chcete, aby jen určití uživatelé otevřeli vaši prezentaci, můžete nastavit omezení otevření. Toto omezení brání lidem vůbec zobrazit obsah vaší prezentace, pokud neposkytnou heslo. Technicky omezení otevření také zabraňuje uživatelům upravovat vaše prezentace — pokud lidé nemohou prezentaci otevřít, nemohou ji ani upravovat nebo měnit.

**Poznámka:** Když chráníte prezentaci heslem, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Ochrana heslem v Aspose.Slides**

**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX and PPT – Microsoft PowerPoint Presentations
- ODP – OpenDocument Presentations
- OTP – OpenDocument Presentation Templates

**Podporované operace**

Aspose.Slides vám umožňuje použít ochranu heslem na prezentacích k zabránění úprav následujícími způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides vám umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace chráněna heslem, před jejím načtením
- Kontrola, zda je prezentace zašifrována
- Kontrola, zda je prezentace chráněna heslem

## **Chránit prezentaci heslem**

Prezentaci můžete zašifrovat nastavením hesla. Poté, aby uživatel mohl upravit uzamčenou prezentaci, musí zadat heslo.

Pro šifrování (nebo ochranu heslem) prezentace použijte metodu `Encrypt` z [ProtectionManager](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager) k nastavení hesla. Heslo předáte metodě `Encrypt` a následně použijete metodu `Save` k uložení nyní zašifrované prezentace.

Tento ukázkový kód ukazuje, jak zašifrovat prezentaci:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Nastavit ochranu proti zápisu na prezentaci** 

Můžete do prezentace přidat značku "Neupravovat". To informuje uživatele, že si nepřejete, aby prováděli změny v prezentaci.

**Poznámka:** Proces ochrany proti zápisu nešifruje prezentaci. Proto uživatelé — pokud si přejí — mohou prezentaci upravovat, ale pro uložení změn ji budou muset uložit pod jiným názvem.

Pro nastavení ochrany proti zápisu použijte metodu `SetWriteProtection`. Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Načíst zašifrovanou prezentaci**

Aspose.Slides vám umožňuje načíst zašifrovanou prezentaci zadáním správného hesla. Tento ukázkový kód ukazuje, jak načíst zašifrovanou prezentaci:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Pracujte s dešifrovanou prezentací.
}
```

## **Odstranit šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace, což umožní uživatelům přístup či úpravy bez omezení.

Pro odstranění šifrování nebo ochrany heslem zavolejte metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/methods/removeencryption). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Odstranit ochranu proti zápisu z prezentace**

Pomocí Aspose.Slides můžete odstranit ochranu proti zápisu ze souboru prezentace. Tímto způsobem ji uživatelé mohou libovolně upravovat a nebudou při tom dostávat žádná varování.

Ochranu proti zápisu můžete odstranit pomocí metody [RemoveWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/methods/removewriteprotection). Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Získat vlastnosti zašifrované prezentace**

Obvykle mají uživatelé potíže se získáním vlastností dokumentu u zašifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost, aby uživatelé přistupovali k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou i vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides vám to umožní.

Pokud chcete, aby uživatelé měli i nadále možnost přístupu k vlastnostem zašifrované prezentace, nastavte vlastnost `EncryptDocumentProperties` rozhraní [IProtectionManager](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/) na `false`. Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a přitom umožnit uživatelům přístup k jejím vlastnostem dokumentu:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Načíst jen vlastnosti dokumentu z zašifrované prezentace**

Pro prozkoumání metadat zašifrované prezentace bez načtení jejích snímků nebo jiného obsahu vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/) a nastavte [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) na `true`. V tomto režimu Aspose.Slides ignoruje heslo a načte jen veřejně přístupné vlastnosti dokumentu.

Následující příklad kódu čte vestavěné i vlastní vlastnosti dokumentu pomocí [IPresentation.DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Tento postup funguje jen v případě, že vlastnosti dokumentu zůstaly po zašifrování prezentace nešifrované (veřejné). Pokud jsou vlastnosti dokumentu zašifrovány, nastavení `OnlyLoadDocumentProperties` na `true` způsobí výjimku, protože heslo je v tomto režimu ignorováno. Pro přístup k šifrovaným vlastnostem dokumentu nebo pro načtení celé prezentace včetně snímků a dalšího obsahu uveďte správnou hodnotu `Password` v [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace můžete chtít zkontrolovat, zda není chráněna heslem. To vám pomůže vyhnout se chybám a podobným problémům, které nastanou při načtení prezentace chráněné heslem bez správného hesla.

Tento C# kód ukazuje, jak prozkoumat prezentaci, zda je chráněna heslem, aniž by se skutečně načetla:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Zkontrolovat, zda je prezentace zašifrována**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace zašifrována. K provedení tohoto úkolu můžete použít vlastnost [IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/properties/isencrypted), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít vlastnost [IsWriteProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/properties/iswriteprotected), která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Ověřit použití hesla u prezentace**

Možná budete chtít ověřit a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky k ověření hesla.

Tento ukázkový kód ukazuje, jak ověřit heslo:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Zkontrolujte, zda heslo odpovídá.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Vrátí `true`, pokud byla prezentace zašifrována zadaným heslem; jinak vrátí `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Chrání prezentaci heslem online**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock). 
1. Klikněte na **Drop or upload your files**.
1. Vyberte soubor, který chcete chránit heslem, ve svém počítači. 
1. Zadejte požadované heslo pro ochranu úprav a požadované heslo pro ochranu zobrazení.
1. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Mark as final**.
1. Klikněte na **PROTECT NOW.** 
1. Klikněte na **DOWNLOAD NOW.**

![Chránit prezentace PowerPoint heslem](slides-lock.png)

## **Často kladené otázky**

**Jaké šifrovací metody podporuje Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň bezpečnosti dat vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, pokud je použito nesprávné heslo, čímž vás upozorní, že přístup k prezentaci byl odepřen. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Mají při práci s prezentacemi chráněnými heslem nějaké dopady na výkon?**

Proces šifrování a dešifrování může během operací otevírání a ukládání zavést mírné zatížení. Ve většině případů je tento dopad na výkon minimální a výrazně neovlivňuje celkovou dobu zpracování vašich úkolů s prezentacemi.