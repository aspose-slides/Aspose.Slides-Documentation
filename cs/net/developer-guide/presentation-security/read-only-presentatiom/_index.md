---
title: Ukládat prezentace v režimu jen pro čtení v .NET
linktitle: Prezentace jen pro čtení
type: docs
weight: 30
url: /cs/net/read-only-presentation/
keywords:
- jen pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides pro .NET, což poskytuje přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Možná budete chtít použít toto nastavení Read-Only k ochraně prezentace, když:

- Chcete zabránit neúmyslným úpravám a udržet obsah své prezentace v bezpečí. 
- Chcete upozornit ostatní, že poskytnutá prezentace je konečná verze. 

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když uživatelé otevřou prezentaci, zobrazí se jim doporučení **Read-Only** a může se zobrazit zpráva v tomto tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor tak, aby se otevřel jen pro čtení.*

Doporučení Read-Only je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon k jeho odstranění, než mohou prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to sdělit zdvořile, může být doporučení Read-Only pro vás dobrá volba. 

> Pokud je prezentace s ochranou **Read-Only** otevřena ve starší verzi Microsoft PowerPointu, která nedisponuje nedávno zavedenou funkcí, doporučení **Read-Only** se ignoruje (prezentace se otevře normálně).

## **Použít režim Read-Only**

Aspose.Slides pro .NET vám umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) vidí doporučení **Read-Only**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci na **Read-Only** v C# pomocí Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 
**Poznámka**: Doporučení **Read-Only** je určeno jen k odrazení úprav nebo zastavení neúmyslných změn v PowerPoint prezentaci. Pokud motivovaná osoba – která ví, co dělá – rozhodne prezentaci upravit, může snadno odstranit nastavení Read-Only. Pokud opravdu potřebujete zabránit neautorizovaným úpravám, je lepší použít [přísnější ochrany zahrnující šifrování a hesla](https://docs.aspose.com/slides/cs/net/password-protected-presentation/). 
{{% /alert %}} 

## **Často kladené otázky**

### Jak se liší 'Read-Only recommended' od úplné ochrany heslem?

'Read-Only recommended' pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a je snadno obejitelný. [Password protection](/slides/cs/net/password-protected-presentation/) ve skutečnosti omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečnou bezpečnostní kontrolu.

### Může být 'Read-Only recommended' kombinováno s vodoznaky pro další odrazení úprav?

Ano. Doporučení může být spojeno s [watermarks](/slides/cs/net/watermark/) jako vizuální odstrašující prvek; jsou to samostatné mechanismy a dobře spolu fungují.

### Může makro nebo externí nástroj stále soubor upravovat, když je doporučení povoleno?

Ano. Doporučení neblokuje programové změny. Pro zabránění automatickým úpravám použijte [passwords and encryption](/slides/cs/net/password-protected-presentation/).

### Jak se 'Read-Only recommended' vztahuje k příznakům 'IsEncrypted' a 'IsWriteProtected'?

Jedná se o odlišné signály. 'Read-Only recommended' je měkká, volitelná výzva; [IsWriteProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/iswriteprotected/) a [IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/isencrypted/) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.