---
title: Ukládejte prezentace v režimu jen pro čtení v .NET
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
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides pro .NET, který nabízí přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení Read-Only můžete chtít použít k ochraně prezentace, když

- Chcete zabránit náhodným úpravám a udržet obsah své prezentace v bezpečí. 
- Chcete upozornit lidi, že poskytnutá prezentace je konečná verze. 

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když ji uživatelé otevřou, uvidí doporučení **Read-Only** a mohou vidět zprávu v tomto tvaru: *Aby se zabránilo náhodným změnám, autor nastavil tento soubor tak, aby se otevíral jen pro čtení.*

Doporučení Read-Only je jednoduchý, ale účinný odrazující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon, aby jej odstranili, než budou moci prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to sdělit slušným způsobem, pak může být doporučení Read-Only pro vás dobrá možnost. 

> Pokud se prezentace s ochranou **Read-Only** otevře ve starší aplikaci Microsoft PowerPoint, která nepodporuje nedávno zavedenou funkci, doporučení **Read-Only** bude ignorováno (prezentace se otevře normálně).

## **Použít režim Read-Only**

Aspose.Slides pro .NET vám umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci na **Read-Only** v C# pomocí Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Poznámka**: Doporučení **Read-Only** je určeno jen k odrazení úprav nebo zastavení uživatelů před náhodnými změnami v PowerPoint prezentaci. Pokud se motivovaná osoba — která ví, co dělá — rozhodne vaši prezentaci upravit, může snadno odstranit nastavení Read-Only. Pokud skutečně potřebujete zabránit neoprávněným úpravám, je lepší použít [přísnější ochrany zahrnující šifrování a hesla](https://docs.aspose.com/slides/cs/net/password-protected-presentation/). 

{{% /alert %}} 

## **Často kladené otázky**

**Jak se liší 'Read-Only recommended' od plné ochrany heslem?**

'Read-Only recommended' pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obe­jit. [Ochrana heslem](/slides/cs/net/password-protected-presentation/) skutečně omezuje otevření nebo úpravy a je vhodná, když potřebujete skutečné bezpečnostní kontroly.

**Lze 'Read-Only recommended' kombinovat s vodoznaky pro další odrazení úprav?**

Ano. Doporučení lze spojit s [vodoznaky](/slides/cs/net/watermark/) jako vizuální odstrašující prostředek; jsou to samostatné mechanismy a dobře spolu fungují.

**Může makro nebo externí nástroj stále soubor upravit, když je doporučení povoleno?**

Ano. Doporučení neblokuje programové změny. Pro zamezení automatických úprav použijte [hesla a šifrování](/slides/cs/net/password-protected-presentation/).

**Jak se 'Read-Only recommended' vztahuje k příznakům 'IsEncrypted' a 'IsWriteProtected'?**

Jedná se o různé signály. 'Read-Only recommended' je měkký, volitelný výzva; [IsWriteProtected](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/iswriteprotected/) a [IsEncrypted](https://reference.aspose.com/slides/cs/net/aspose.slides/protectionmanager/isencrypted/) označují skutečná omezení zápisu nebo čtení, která závisí na heslech či šifrování.