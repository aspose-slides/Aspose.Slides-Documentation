---
title: Uložení prezentací v režimu jen pro čtení pomocí Pythonu
linktitle: Prezentace jen pro čtení
type: docs
weight: 30
url: /cs/python-java/read-only-presentation/
keywords:
- jen pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides for Python via Java, což poskytuje přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení jen pro čtení můžete využít, když:

- Chcete zabránit neúmyslným úpravám a ochránit obsah své prezentace.
- Chcete upozornit ostatní, že poskytnutá prezentace je konečná verze.

Po výběru možnosti **Always Open Read-Only** pro prezentaci uvidí uživatelé při otevření prezentace doporučení **Read-Only** a mohou vidět zprávu v tomto tvaru: *Aby se předešlo neúmyslným změnám, autor nastavil tento soubor jako jen pro čtení.*

Doporučení **Read-Only** je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést akci k jeho odstranění, než jim bude umožněno prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete je o tom informovat zdvořile, může být doporučení **Read-Only** pro vás dobrá volba.

> Pokud se prezentace s ochranou **Read-Only** otevře ve starší verzi Microsoft PowerPointu, která nedokáže nedávno zavedenou funkci podporovat, doporučení **Read-Only** se ignoruje (prezentace se otevře normálně).

## **Použít režim jen pro čtení**

Aspose.Slides for Python via Java vám umožňuje nastavit prezentaci jako **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód ukazuje, jak nastavit prezentaci jako **Read-Only** v Pythonu pomocí Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Poznámka" %}} 

Doporučení **Read-Only** je určeno jen k odrazení úprav nebo k zastavení neúmyslných změn v PowerPointové prezentaci. Pokud se motivovaná osoba – která ví, co dělá – rozhodne vaši prezentaci upravit, může snadno nastavení **Read-Only** odstranit. Pokud skutečně potřebujete zabránit neautorizovaným úpravám, je vhodnější použít [přísnější ochranu, která zahrnuje šifrování a hesla](/slides/cs/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **Často kladené otázky**

**Jaký je rozdíl mezi „Read-Only recommended“ a plnou ochranou heslem?**  

„Read-Only recommended“ pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obejít. [Ochrana heslem](/slides/cs/python-java/password-protected-presentation/) skutečně omezuje otevírání nebo úpravy a je vhodná, když potřebujete reálné bezpečnostní kontroly.

**Lze „Read-Only recommended“ zkombinovat s vodoznaky, aby se ještě více odradily úpravy?**  

Ano. Doporučení lze spojit s [vodoznaky](/slides/cs/python-java/watermark/) jako vizuálním odstrašujícím prostředkem; jedná se o samostatné mechanismy, které spolu dobře fungují.

**Může makro nebo externí nástroj soubor stále upravit, i když je doporučení povoleno?**  

Ano. Doporučení neblokuje programové změny. Pro zabránění automatickým úpravám použijte [hesla a šifrování](/slides/cs/python-java/password-protected-presentation/).

**Jak se „Read-Only recommended“ vztahuje k metodám [isEncrypted](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#isEncrypted) a [isWriteProtected](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**  

Jedná se o odlišné signály. „Read-Only recommended“ je měkká, volitelná výzva; [isWriteProtected](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#isWriteProtected) a [isEncrypted](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#isEncrypted) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech či šifrování.