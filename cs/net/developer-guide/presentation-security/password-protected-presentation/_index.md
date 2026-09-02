---
title: Ochrana prezentací heslem v .NET
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/net/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrovat PowerPoint
- dešifrovat PowerPoint
- ověřit heslo prezentace
- kontrolovat heslo prezentace
- otevřít šifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v C# pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno k načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/net/write-protected-presentation/).

Níže uvedené postupy platí pro prezentace ve formátech PPT i PPTX. Příklady používají oba formáty, kde je důležité chování při práci se soubory i s proudy.

## **Šifrování prezentace pomocí otevíracího hesla**

Pro přiřazení otevíracího hesla použijte [IProtectionManager.Encrypt](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/encrypt/). Poté použijte [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) k uložení šifrované prezentace.

Následující příklad šifruje PPTX prezentaci:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Načtení šifrované prezentace**

Nastavte [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) na otevírací heslo a při načítání souboru předáte možnosti třídě [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Načítání selže, pokud je vyžadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Pracujte s dešifrovanou prezentací.
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/removeencryption/) a výsledek uložte. Uloženou prezentaci lze poté načíst bez hesla.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Ověření otevíracího hesla před načtením**

Použijte [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationfactory/getpresentationinfo/) pro získání [IPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/) bez vytvoření kompletní instance prezentace. Před požádáním o heslo nebo jeho ověřením zkontrolujte [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/ispasswordprotected/). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Postup s cestou k souboru**

Následující příklad ověřuje otevírací heslo pro soubor PPTX, předá ověřenou hodnotu do [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) a následně načte kompletní prezentaci:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Postup s proudem**

Varianta s proudem pro [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationfactory/getpresentationinfo/) nabízí stejný postup. Před načtením kompletní prezentace z tohoto proudu nastavte pozici vyhledatelného proudu zpět na začátek.

Následující příklad používá soubor PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Návratové hodnoty metody CheckPassword**

Metoda [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/checkpassword/) vrací `true` pouze, pokud má prezentace otevírací heslo a zadané heslo je správné. V následujících případech vrací `false`:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Zjištění, zda je načtená prezentace šifrována**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/isencrypted/) pro potvrzení, že původní prezentace byla šifrována. Pro zjištění ochrany otevíracím heslem před načtením použijte `IPresentationInfo.IsPasswordProtected`, jak je uvedeno výše.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Security" %}}
Nezaznamenávejte otevírací hesla ani je neuvádějte v diagnostických zprávách. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po dobu, kdy jsou potřeba, a při okamžitém načtení prezentace použijte úspěšný výsledek ověření znovu.
{{% /alert %}}

## **Zabezpečení prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
2. Vyberte nebo nahrajte prezentaci.
3. Zadejte heslo pro ochranu prohlížení.
4. Volitelně zadejte samostatné heslo pro ochranu úprav.
5. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="See also" %}}
- [Prezentace chráněné proti zápisu](/slides/cs/net/write-protected-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**O jaký rozdíl jde mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno k načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy, aniž by šifrovalo obsah.

**Mohu ověřit otevírací heslo, aniž bych načetl všechny snímky?**

Ano. Získejte informace o prezentaci, ověřte, zda je přítomna ochrana otevíracím heslem, a validujte heslo před vytvořením kompletní instance prezentace.

**Podporují postupy kontroly hesla jak PPT, tak PPTX?**

Ano. Detekce a ověřování hesla na základě cesty k souboru i proudu funguje stejně pro prezentace PPT i PPTX.