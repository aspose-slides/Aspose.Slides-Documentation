---
title: Zabezpečení prezentací hesly v .NET
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/net/password-protected-presentation/
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
- zabezpečení PowerPoint
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
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak snadno zamknout a odemknout heslem chráněné prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, znamená to, že nastavujete heslo, které vynutí určitá omezení na prezentaci. Pro odstranění těchto omezení je nutné zadat heslo. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Obvykle můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úprava**

Pokud chcete, aby jen určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat prvky ve vaší prezentaci, pokud nezadají heslo. Nicméně i bez hesla bude uživatel i nadále schopen přistupovat k vašemu dokumentu a otevřít jej. V tomto režimu jen pro čtení může uživatel zobrazit obsah – včetně hypertextových odkazů, animací, efektů a dalších prvků – ve vaší prezentaci, ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

Pokud chcete, aby jen určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec zobrazit obsah vaší prezentace, pokud nezadají heslo. Technicky toto omezení otevření také zabraňuje uživatelům upravovat vaše prezentace – pokud lidé nemohou prezentaci otevřít, nemohou ji upravovat ani měnit.

**Poznámka:** Když chráníte prezentaci heslem tak, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Ochrana heslem v Aspose.Slides**

**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Prezentace Microsoft PowerPoint
- ODP – Prezentace OpenDocument
- OTP – Šablony prezentací OpenDocument

**Podporované operace**

Aspose.Slides vám umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám, následujícími způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním následujícími způsoby:

- Dešifrování prezentace; otevření šifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností šifrované prezentace
- Kontrola, zda je prezentace chráněna heslem, před jejím načtením
- Kontrola, zda je prezentace šifrovaná
- Kontrola, zda je prezentace chráněna heslem

## **Chránit prezentaci heslem**

Můžete šifrovat prezentaci nastavením hesla. Pak, aby uživatel mohl upravit uzamčenou prezentaci, musí zadat heslo.

Pro šifrování (nebo ochranu heslem) prezentace použijte metodu `Encrypt` z [ProtectionManager](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager), aby jste nastavili heslo. Heslo předáte metodě `Encrypt` a poté použijete metodu `Save` k uložení nyní šifrované prezentace.

Tento ukázkový kód vám ukazuje, jak šifrovat prezentaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Nastavit ochranu proti zápisu na prezentaci** 

Můžete k prezentaci přidat označení „Neupravit“. To informuje uživatele, že si nepřejete, aby prováděli změny v prezentaci.

**Poznámka:** Proces ochrany proti zápisu prezentaci nešifruje. Proto uživatelé – pokud chtějí – mohou prezentaci upravovat, ale pro uložení změn ji budou muset uložit pod jiným názvem.

Pro nastavení ochrany proti zápisu použijte metodu `SetWriteProtection`. Tento ukázkový kód vám ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Načíst šifrovanou prezentaci**

Aspose.Slides vám umožňuje načíst šifrovanou prezentaci předáním správného hesla. Tento ukázkový kód vám ukazuje, jak načíst šifrovanou prezentaci:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Pracujte s dešifrovanou prezentací.
}
```

## **Odstranit šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace, což uživatelům umožní přístup nebo úpravy bez omezení.

Pro odstranění šifrování nebo ochrany heslem zavolejte metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/methods/removeencryption). Tento ukázkový kód vám ukazuje, jak odstranit šifrování z prezentace:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Odstranit ochranu proti zápisu z prezentace**

Můžete použít Aspose.Slides k odstranění ochrany proti zápisu ze souboru prezentace. Tímto způsobem ji uživatelé mohou libovolně upravovat – a nebudou při tom dostávat žádná varování.

Ochranu proti zápisu můžete odstranit pomocí metody [RemoveWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/methods/removewriteprotection). Tento ukázkový kód vám ukazuje, jak odstranit ochranu proti zápisu z prezentace:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Získat vlastnosti šifrované prezentace**

Obvykle mají uživatelé potíže získat vlastnosti dokumentu šifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a přitom zachovat možnost, aby uživatelé přistupovali k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides šifruje prezentaci, jsou také vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides umožňuje právě to.

Pokud chcete, aby uživatelé měli zachován přístup k vlastnostem šifrované prezentace, nastavte vlastnost `EncryptDocumentProperties` objektu [IProtectionManager](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/) na `false`. Tento ukázkový kód vám ukazuje, jak šifrovat prezentaci a přitom uživatelům poskytnout přístup k vlastnostem dokumentu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Načíst pouze vlastnosti dokumentu ze šifrované prezentace**

Pro prozkoumání metadat šifrované prezentace bez načítání snímků či dalšího obsahu vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/) a nastavte [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) na `true`. V tomto režimu Aspose.Slides ignoruje heslo a načte pouze veřejně přístupné vlastnosti dokumentu.

Následující ukázkový kód čte vestavěné i vlastní vlastnosti dokumentu pomocí [IPresentation.DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Přečtěte vestavěné vlastnosti dokumentu.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Přečtěte uživatelské vlastnosti dokumentu.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Tento postup funguje pouze tehdy, když byly vlastnosti dokumentu při šifrování prezentace ponechány nešifrované (veřejné). Pokud jsou vlastnosti dokumentu šifrované, nastavení `OnlyLoadDocumentProperties` na `true` vyvolá výjimku, protože v tomto režimu je heslo ignorováno. Pro přístup k šifrovaným vlastnostem dokumentu nebo načtení kompletní prezentace, včetně snímků a dalšího obsahu, zadejte správnou hodnotu `Password` v [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace můžete chtít zkontrolovat, zda není chráněna heslem. To vám pomůže vyhnout se chybám a podobným problémům, ke kterým dochází, když je prezentace chráněna heslem načtena bez správného hesla.

Tento C# kód vám ukazuje, jak prozkoumat prezentaci, zda je chráněna heslem, aniž byste ji skutečně načetli:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Zkontrolovat, zda je prezentace šifrovaná**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace šifrovaná. K provedení této úlohy můžete použít vlastnost [IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/properties/isencrypted), která vrací `true`, pokud je prezentace šifrovaná, nebo `false`, pokud není.

Tento ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace šifrovaná:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení této úlohy můžete použít vlastnost [IsWriteProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/properties/iswriteprotected), která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není.

Tento ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Ověřit použití hesla prezentace**

Možná budete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro ověření hesla.

Tento ukázkový kód vám ukazuje, jak ověřit heslo:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Zkontrolujte, zda heslo odpovídá.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Vrátí `true`, pokud byla prezentace zašifrována uvedeným heslem; jinak vrátí `false`.

{{% alert color="info" title="Viz také" %}} 
- [Digitální podpis v PowerPoint](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock). 
2. Klikněte na **Přetáhněte nebo nahrajte soubory**. 
3. Vyberte soubor, který chcete chránit heslem, ve svém počítači. 
4. Zadejte požadované heslo pro ochranu úprav a požadované heslo pro ochranu zobrazení. 
5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Mark as final**. 
6. Klikněte na **PROTECT NOW.** 
7. Klikněte na **DOWNLOAD NOW.**

![Ochrana heslem PowerPoint prezentací](slides-lock.png)

## **Časté otázky**

**Jaké šifrovací metody podporuje Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, čímž zajišťuje vysokou úroveň zabezpečení vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, pokud je použito nesprávné heslo, což vás upozorní, že přístup k prezentaci byl odepřen. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Mají ochrana heslem prezentací vliv na výkon?**

Proces šifrování a dešifrování může během operací otevírání a ukládání zavést drobné zatížení. Ve většině případů je tento dopad na výkon minimální a významně neovlivňuje celkovou dobu zpracování vašich úkolů s prezentacemi.