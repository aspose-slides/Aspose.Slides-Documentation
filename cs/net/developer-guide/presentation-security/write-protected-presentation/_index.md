---
title: Zabezpečení prezentací proti zápisu v .NET
linktitle: Ochrana proti zápisu
type: docs
weight: 25
url: /cs/net/write-protected-presentation/
keywords:
- ochrana proti zápisu
- ochrana proti zápisu PowerPointu
- heslo pro úpravu
- omezit úpravy prezentace
- odstranit ochranu proti zápisu
- ověřit heslo pro úpravy
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Nastavte, detekujte, ověřte a odstraňte hesla ochrany proti zápisu v prezentacích PowerPoint PPT a PPTX pomocí Aspose.Slides pro .NET."
---
## **Úvod**

Heslo pro ochranu proti zápisu omezuje úpravy prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou proti zápisu bez hesla. V závislosti na aplikaci mohou také upravovat obsah a uložit jej pod jiným názvem, takže ochrana proti zápisu by neměla být považována za mechanismus důvěrnosti.

Otevírací heslo slouží k odlišnému účelu: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Pro zašifrování prezentace nebo ověření otevíracího hesla viz [Ochrana heslem prezentací](/slides/cs/net/password-protected-presentation/).

Postupy v tomto článku platí jak pro prezentace PPT, tak PPTX. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát uložení PPT.

## **Nastavit ochranu proti zápisu na prezentaci**

Použijte [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/setwriteprotection/) k přiřazení hesla pro úpravu prezentace. Uložení prezentace zachová nastavení ochrany.

Následující příklad nastavuje ochranu proti zápisu na prezentaci PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Načtení prezentace chráněné proti zápisu**

Protože ochrana proti zápisu nešifruje obsah prezentace, není k načtení prezentace vyžadováno žádné heslo. Heslo je relevantní pouze při ověřování oprávnění k úpravě chráněné prezentace.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Nezadejte heslo pro ochranu proti zápisu do [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/). Tato vlastnost přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, poskytněte otevírací heslo pro její načtení a heslo pro ochranu proti zápisu zpracujte samostatně.

## **Odstranění ochrany proti zápisu z prezentace**

Použijte [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/removewriteprotection/) k odebrání omezení úprav, poté prezentaci uložte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Chcete-li prověřit soubor, aniž byste vytvářeli úplnou instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/), zavolejte [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationfactory/getpresentationinfo/) a zkontrolujte [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/iswriteprotected/). Vlastnost používá [NullableBool](https://reference.aspose.com/slides/cs/net/aspose.slides/nullablebool/) a vrací `NullableBool.True`, když je detekována ochrana proti zápisu.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Přetížení pro proud (stream) metody [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationfactory/getpresentationinfo/) poskytuje stejné informace pro prezentaci předanou jako proud.

## **Ověření hesla pro ochranu proti zápisu**

Použijte [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/checkwriteprotection/) k ověření hesla pro úpravy bez načtení úplné prezentace. Nejprve zkontrolujte [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/iswriteprotected/), aby aplikace požadovala nebo ověřovala heslo pouze v případě, že je ochrana proti zápisu přítomna.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/checkwriteprotection/) ověřuje pouze heslo pro ochranu proti zápisu. Neověřuje otevírací heslo ani neurčuje, zda lze načíst zašifrovaný obsah. Naopak [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/checkpassword/) ověřuje pouze otevírací heslo. Pokud již byla načtena úplná prezentace, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/cs/net/aspose.slides/iprotectionmanager/checkwriteprotection/) poskytuje ekvivalentní kontrolu ochrany proti zápisu prostřednictvím svého správce ochrany.

V produkčních aplikacích nelogujte hesla ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti pouze po dobu, kdy jsou potřebná.

{{% alert color="info" title="Viz také" %}}
- [Ochrana prezentací heslem](/slides/cs/net/password-protected-presentation/)
- [Prezentace jen pro čtení](/slides/cs/net/read-only-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Šifruje ochrana proti zápisu prezentaci?**

Ne. Omezuje úpravy, ale ponechává obsah prezentace dostupný pro načtení a prohlížení.

**Je heslo pro ochranu proti zápisu vyžadováno pro otevření prezentace?**

Ne. Pouze otevírací heslo je vyžadováno pro načtení šifrovaného obsahu prezentace.

**Může mít prezentace jak otevírací heslo, tak heslo pro ochranu proti zápisu?**

Ano. Otevírací heslo poskytněte prostřednictvím možností načtení pro otevření šifrované prezentace a heslo pro ochranu proti zápisu ověřujte samostatně, když je vyžadováno oprávnění k úpravám.