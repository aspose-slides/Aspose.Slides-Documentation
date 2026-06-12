---
title: Uložení prezentací v režimu pouze pro čtení pomocí C++
linktitle: Prezentace pouze pro čtení
type: docs
weight: 30
url: /cs/cpp/read-only-presentation/
keywords:
- pouze pro čtení
- ochrana prezentace
- zabránění úpravám
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu pouze pro čtení pomocí Aspose.Slides pro C++, což poskytuje přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení Read-Only můžete chtít použít k ochraně prezentace, když

- Chcete zabránit neúmyslným úpravám a udržet obsah prezentace v bezpečí. 
- Chcete upozornit lidi, že poskytnutá prezentace je finální verze. 

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když uživatelé prezentaci otevřou, uvidí doporučení **Read-Only** a mohou vidět zprávu v tomto tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor tak, aby se otevřel jen pro čtení.*

Doporučení **Read-Only** je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon k jeho odstranění, než jim bude povoleno prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to sdělit slušně, může být doporučení **Read-Only** pro vás dobrou volbou. 

> Pokud se prezentace s ochranou **Read-Only** otevře ve starší aplikaci Microsoft PowerPoint, která nepodporuje nedávno zavedenou funkci, doporučení **Read-Only** bude ignorováno (prezentace se otevře normálně).

## **Použít režim Read-Only**

Aspose.Slides pro C++ vám umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci na **Read-Only** v C++ pomocí Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Poznámka**: Doporučení **Read-Only** je určeno jen k odrazení úprav nebo zastavení uživatelů před neúmyslnými změnami v prezentaci PowerPoint. Pokud se motivovaná osoba—která ví, co dělá—rozhodne vaši prezentaci upravit, může snadno odebrat nastavení Read-Only. Pokud skutečně potřebujete zabránit neautorizovaným úpravám, je lepší použít [přísnější ochrany, které zahrnují šifrování a hesla](https://docs.aspose.com/slides/cs/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **Často kladené otázky**

**Jak se liší 'Read-Only recommended' od úplné ochrany heslem?**

'Read-Only recommended' pouze zobrazuje návrh otevřít soubor v režimu pouze pro čtení a je snadno obejitelný. [Password protection](/slides/cs/cpp/password-protected-presentation/) ve skutečnosti omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečná bezpečnostní opatření.

**Lze 'Read-Only recommended' kombinovat s vodoznaky, aby se ještě více odrazovaly úpravy?**

Ano. Doporučení lze spojit s [watermarks](/slides/cs/cpp/watermark/) jako vizuálním odstrašujícím prostředkem; jsou to samostatné mechanismy a dobře spolu fungují.

**Může makro nebo externí nástroj stále soubor upravit, když je doporučení povoleno?**

Ano. Doporučení neblokuje programové změny. Pro zabránění automatickým úpravám použijte [passwords and encryption](/slides/cs/cpp/password-protected-presentation/).

**Jak se 'Read-Only recommended' vztahuje k příznakům 'is encrypted' a 'is write protected'?**

Jedná se o různé signály. 'Read-Only recommended' je měkká, volitelná výzva; [get_IsWriteProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) a [get_IsEncrypted](https://reference.aspose.com/slides/cs/cpp/aspose.slides/protectionmanager/get_isencrypted/) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.