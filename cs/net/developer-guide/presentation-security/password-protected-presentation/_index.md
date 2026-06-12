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
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak snadno uzamykat a odemykat prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro .NET. Zabezpečte své prezentace."
---
## **Úvod**

Když prezentaci chráníte heslem, nastavujete heslo, které uplatňuje určitá omezení na prezentaci. Pro odebrání těchto omezení je nutné zadat heslo. Prezentace chráněná heslem se považuje za zamčenou prezentaci.

Obvykle můžete nastavit heslo, aby byla tato omezení na prezentaci vynucena:

- **Úpravy**

Pokud chcete, aby jen vybraní uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úprav. Toto omezení brání lidem v úpravě, změně nebo kopírování prvků v prezentaci, pokud nezadají heslo.

I bez hesla však uživatel stále může dokument otevřít a zobrazit. V režimu jen pro čtení může uživatel prohlížet obsah — včetně hypertextových odkazů, animací, efektů a dalších prvků — ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

Pokud chcete, aby jen vybraní uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení brání lidem v jakémkoli prohlížení obsahu prezentace, pokud nezadají heslo.

Technicky omezení otevření také zabraňuje uživatelům upravovat prezentaci — pokud lidé nemohou prezentaci otevřít, nemohou ji ani měnit.

**Poznámka:** Když prezentaci chráníte heslem tak, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Ochrana heslem v Aspose.Slides**

**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint prezentace
- ODP – OpenDocument prezentace
- OTP – OpenDocument šablony prezentací

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích a zabránit úpravám následujícími způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním následujícím způsobem:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace chráněna heslem, před jejím načtením
- Kontrola, zda je prezentace zašifrována
- Kontrola, zda je prezentace chráněna heslem

## **Ochrana prezentace heslem**

Můžete prezentaci zašifrovat nastavením hesla. Poté, aby uživatel mohl upravit zamčenou prezentaci, musí zadat heslo.

Pro šifrování (nebo ochranu heslem) prezentace použijte metodu `Encrypt` z [ProtectionManager](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager) a nastavte heslo. Heslo předáte metodě `Encrypt` a poté použijte metodu `Save` k uložení nyní zašifrované prezentace.

Tento ukázkový kód ukazuje, jak prezentaci zašifrovat:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Nastavení ochrany proti zápisu na prezentaci** 

Můžete přidat značku "Nemiňte" do prezentace. Tím informujete uživatele, že nechcete, aby prováděli změny v prezentaci.

**Poznámka:** Proces ochrany proti zápisu prezentaci nešifruje. Uživatelé — pokud chtějí — ji mohou upravit, ale pro uložení změn ji musí uložit pod jiným názvem.

Pro nastavení ochrany proti zápisu použijte metodu `SetWriteProtection`. Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Načtení zašifrované prezentace**

Aspose.Slides umožňuje načíst zašifrovanou prezentaci zadáním správného hesla. Tento ukázkový kód ukazuje, jak načíst zašifrovanou prezentaci:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Pracujte s dešifrovanou prezentací.
}
```

## **Odstranění šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace, což uživatelům umožní přístup nebo úpravy bez omezení.

Pro odstranění šifrování nebo ochrany heslem zavolejte metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/methods/removeencryption). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Odstranění ochrany proti zápisu z prezentace**

Můžete pomocí Aspose.Slides odstranit ochranu proti zápisu z souboru prezentace. Tím umožníte uživatelům libovolně upravovat a nebudou při tom dostávat žádná varování.

Ochranu proti zápisu můžete odstranit pomocí metody [RemoveWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/methods/removewriteprotection). Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Získání vlastností zašifrované prezentace**

Obvykle uživatelé mají problém získat vlastnosti dokumentu zašifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost přístupu k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou i její vlastnosti dokumentu chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides tuto možnost poskytuje.

Pokud chcete, aby uživatelé i po zašifrování mohli přistupovat k vlastnostem prezentace, nastavte vlastnost [EncryptDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) na `true`. Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Kontrola, zda je prezentace chráněna heslem**

Před načtením prezentace můžete chtít ověřit, že není chráněna heslem. To pomáhá předejít chybám a podobným problémům, které nastanou při načítání prezentace chráněné heslem bez správného hesla.

Tento C# kód ukazuje, jak zkontrolovat, zda je prezentace chráněna heslem, aniž byste ji načítali:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Kontrola, zda je prezentace zašifrována**

Aspose.Slides umožňuje zjistit, zda je prezentace zašifrována. K tomuto účelu můžete použít vlastnost [IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/properties/isencrypted), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Aspose.Slides umožňuje zjistit, zda je prezentace chráněna proti zápisu. K tomuto účelu můžete použít vlastnost [IsWriteProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/properties/iswriteprotected), která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Ověření použití hesla u prezentace**

Možná budete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro validaci hesla.

Tento ukázkový kód ukazuje, jak validovat heslo:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Zkontrolujte, zda heslo odpovídá.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Vrací `true`, pokud byla prezentace zašifrována zadaným heslem; jinak vrací `false`.

{{% alert color="primary" title="Viz také" %}} 
- [Digital Signature in PowerPoint](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock).
1. Klikněte na **Drop or upload your files**.
1. Vyberte soubor, který chcete chránit heslem, ve svém počítači.
1. Zadejte preferované heslo pro ochranu úprav a preferované heslo pro ochranu zobrazení.
1. Pokud chcete, aby uživatelé viděli prezentaci jako finální kopii, zaškrtněte políčko **Mark as final**.
1. Klikněte na **PROTECT NOW.**
1. Klikněte na **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **Často kladené otázky**

**Jaké šifrovací metody Aspose.Slides podporuje?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení dat vašich prezentací.

**Co se stane, když je zadáno nesprávné heslo při pokusu o otevření prezentace?**

Vyvolá se výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Mají password‑protected prezentace vliv na výkon?**

Proces šifrování a dešifrování může během otevírání a ukládání přinést mírné zatížení. Ve většině případů je tento dopad minimální a významně neovlivní celkovou dobu zpracování vašich úkolů s prezentacemi.