---
title: Uložení prezentací v režimu pouze pro čtení pomocí Pythonu
linktitle: Prezentace pouze pro čtení
type: docs
weight: 30
url: /cs/python-net/read-only-presentation/
keywords:
- pouze pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu pouze pro čtení pomocí Aspose.Slides pro Python prostřednictvím .NET, což poskytuje přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Můžete chtít použít toto nastavení pouze pro čtení k ochraně prezentace, když

- Chcete zabránit nechtěným úpravám a udržet obsah své prezentace v bezpečí.
- Chcete upozornit, že prezentace, kterou jste poskytli, je finální verze.

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když uživatelé otevřou prezentaci, uvidí doporučení **Read-Only** a mohou vidět zprávu v tomto tvaru: *Aby se zabránilo nechtěným změnám, autor nastavil tento soubor tak, aby se otevíral jen pro čtení.*

Doporučení **Read-Only** je jednoduché, ale účinné odstrašující opatření, které odrazuje od úprav, protože uživatelé musí provést úkon k jeho odstranění, než jim bude umožněno prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to sdělit zdvořile, může být doporučení **Read-Only** pro vás dobrá volba.

> Pokud je prezentace s ochranou **Read-Only** otevřena ve starší aplikaci Microsoft PowerPoint, která nedisponuje nedávno zavedenou funkcí, doporučení **Read-Only** se ignoruje (prezentace se otevře normálně).

## **Použít režim pouze pro čtení**

Aspose.Slides pro Python prostřednictvím .NET vám umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci na **Read-Only** v Pythonu pomocí Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Poznámka**: Doporučení **Read-Only** je určeno k odrazení úprav nebo zastavení nechtěných změn v PowerPoint prezentaci. Pokud se motivovaná osoba—která ví, co dělá—rozhodne vaši prezentaci upravit, může snadno nastavení **Read-Only** odstranit. Pokud skutečně potřebujete zabránit neoprávněným úpravám, je lepší použít [přísnější ochrany zahrnující šifrování a hesla](https://docs.aspose.com/slides/cs/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **Často kladené otázky**

**Jak se liší 'Read-Only recommended' od úplné ochrany heslem?**

'Read-Only recommended' pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obejít. [Ochrana heslem](/slides/cs/python-net/password-protected-presentation/) skutečně omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečná bezpečnostní opatření.

**Lze 'Read-Only recommended' kombinovat s vodoznaky pro další odrazení úprav?**

Ano. Doporučení lze spojit s [vodoznaky](/slides/cs/python-net/watermark/) jako vizuálním odstrašujícím prostředkem; jsou to samostatné mechanismy a dobře spolupracují.

**Může makro nebo externí nástroj soubor stále upravovat, když je doporučení povoleno?**

Ano. Doporučení neblokuje programové změny. Pro zamezení automatizovaných úprav použijte [hesla a šifrování](/slides/cs/python-net/password-protected-presentation/).

**Jak se 'Read-Only recommended' vztahuje k příznakům 'is_encrypted' a 'is_write_protected'?**

Jedná se o odlišné signály. 'Read-Only recommended' je měkké, volitelné upozornění; [is_write_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/is_write_protected/) a [is_encrypted](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/is_encrypted/) naznačují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.