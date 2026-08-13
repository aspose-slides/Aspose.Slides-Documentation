---
title: Ukládání prezentací v režimu Pouze pro čtení pomocí C++
linktitle: Prezentace Pouze pro čtení
type: docs
weight: 30
url: /cs/cpp/read-only-presentation/
keywords:
- pouze pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu pouze pro čtení pomocí Aspose.Slides pro C++, což umožňuje přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Vždy otevřít jako Pouze pro čtení** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Můžete chtít použít toto nastavení Pouze pro čtení k ochraně prezentace, když

- Chcete zabránit náhodným úpravám a udržet obsah vaší prezentace v bezpečí. 
- Chcete upozornit lidi, že poskytovaná prezentace je finální verzí. 

Po výběru možnosti **Vždy otevřít jako Pouze pro čtení** pro prezentaci, když uživatelé otevřou prezentaci, uvidí doporučení **Pouze pro čtení** a mohou vidět zprávu ve tvaru: *Aby se zabránilo náhodným změnám, autor nastavil tento soubor tak, aby byl otevřen jen pro čtení.*

Doporučení Pouze pro čtení je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon k jeho odstranění, než jim bude dovoleno prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chtěli byste jim to sdělit zdvořile, může být doporučení Pouze pro čtení pro vás dobrá volba.

> Pokud se prezentace s ochranou **Pouze pro čtení** otevře ve starší aplikaci Microsoft PowerPoint, která nedisponuje nedávno zavedenou funkcí, doporučení **Pouze pro čtení** bude ignorováno (prezentace se otevře normálně).

## **Použít režim Pouze pro čtení**

Aspose.Slides for C++ vám umožňuje nastavit prezentaci jako **Pouze pro čtení**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Pouze pro čtení**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci jako **Pouze pro čtení** v C++ pomocí Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 
**Poznámka**: Doporučení **Pouze pro čtení** je určeno jen k odrazení úprav nebo zastavení uživatelů před náhodnými změnami v PowerPoint prezentaci. Pokud se motivovaná osoba—která ví, co dělá—rozhodne vaši prezentaci upravit, může nastavení Pouze pro čtení snadno odstranit. Pokud opravdu potřebujete zabránit neautorizovaným úpravám, je lepší použít [přísnější ochrany zahrnující šifrování a hesla](https://docs.aspose.com/slides/cs/cpp/password-protected-presentation/). 
{{% /alert %}} 

## **Často kladené otázky**

### Jak se liší 'Doporučení Pouze pro čtení' od plné ochrany heslem?

'Doporučení Pouze pro čtení' pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obejít. [Ochrana heslem](/slides/cs/cpp/password-protected-presentation/) skutečně omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečné bezpečnostní kontroly.

### Může být 'Doporučení Pouze pro čtení' kombinováno s vodoznaky pro další odrazení úprav?

Ano. Doporučení lze spárovat s [vodoznaky](/slides/cs/cpp/watermark/) jako vizuální odstrašující prostředek; jsou to samostatné mechanismy a dobře spolu fungují.

### Může makro nebo externí nástroj stále soubor upravit, když je doporučení povoleno?

Ano. Doporučení neblokuje programové změny. K zabránění automatických úprav použijte [hesla a šifrování](/slides/cs/cpp/password-protected-presentation/).

### Jak se 'Doporučení Pouze pro čtení' vztahuje k příznakům 'is encrypted' a 'is write protected'?

Jedná se o odlišné signály. 'Doporučení Pouze pro čtení' je měkký, volitelný výzva; [get_IsWriteProtected](https://reference.aspose.com/slides/cs/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) a [get_IsEncrypted](https://reference.aspose.com/slides/cs/cpp/aspose.slides/protectionmanager/get_isencrypted/) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.