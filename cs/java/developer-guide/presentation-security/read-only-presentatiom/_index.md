---
title: Uložení prezentací v režimu jen pro čtení pomocí Javy
linktitle: Prezentace jen pro čtení
type: docs
weight: 30
url: /cs/java/read-only-presentation/
keywords:
- jen pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides pro Javu, což poskytuje přesné náhledy snímků bez úprav vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení Read-Only můžete chtít použít k ochraně prezentace, když

- Chcete zabránit neúmyslným úpravám a udržet obsah své prezentace v bezpečí. 
- Chcete upozornit ostatní, že poskytnutá prezentace je konečná verze. 

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když uživatelé otevřou prezentaci, uvidí doporučení **Read-Only** a mohou vidět zprávu ve tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor tak, aby se otevřel jen pro čtení.*

Doporučení Read-Only je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon k jeho odstranění, než jim bude umožněno prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to sdělit zdvořilým způsobem, pak může být doporučení Read-Only pro vás dobrá volba. 

> Pokud je prezentace s ochranou **Read-Only** otevřena ve starší aplikaci Microsoft PowerPoint, která nově zavedenou funkci nepodporuje, doporučení **Read-Only** se ignoruje (prezentace se otevře normálně).

## **Použít režim Read-Only**

Aspose.Slides for Java vám umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci na **Read-Only** v Javě pomocí Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Poznámka**: Doporučení **Read-Only** je určeno jen k odrazení úprav nebo zastavení neúmyslných změn v PowerPointové prezentaci. Pokud se motivovaná osoba—která ví, co dělá—rozhodne vaši prezentaci upravit, může snadno odstranit nastavení Read-Only. Pokud opravdu potřebujete zabránit neautorizovaným úpravám, je lepší použít [přísnější ochranu, která zahrnuje šifrování a hesla](https://docs.aspose.com/slides/cs/java/password-protected-presentation/). 

{{% /alert %}} 

## **Často kladené otázky**

### Jak se liší 'Read-Only recommended' od úplné ochrany heslem?

'Read-Only recommended' pouze zobrazí návrh otevřít soubor v režimu jen pro čtení a snadno se obejde. [Password protection](/slides/cs/java/password-protected-presentation/) ve skutečnosti omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečné bezpečnostní kontroly.

### Může být 'Read-Only recommended' kombinováno s vodoznaky pro další odrazení úprav?

Ano. Doporučení může být spojeno s [watermarks](/slides/cs/java/watermark/) jako vizuální odstrašuje; jsou to samostatné mechanismy a dobře spolu fungují.

### Může makro nebo externí nástroj stále soubor upravit, když je doporučení povoleno?

Ano. Doporučení neblokuje programové změny. Pro zabránění automatickým úpravám použijte [passwords and encryption](/slides/cs/java/password-protected-presentation/).

### Jak se 'Read-Only recommended' vztahuje k metodám 'isEncrypted' a 'isWriteProtected'?

Jedná se o odlišné signály. 'Read-Only recommended' je měkká, volitelná výzva; [isWriteProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/protectionmanager/#isWriteProtected--) a [isEncrypted](https://reference.aspose.com/slides/cs/java/com.aspose.slides/protectionmanager/#isEncrypted--) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech či šifrování.