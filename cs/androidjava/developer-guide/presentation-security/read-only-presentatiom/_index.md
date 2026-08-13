---
title: Uložit prezentace v režimu jen pro čtení na Androidu
linktitle: Prezentace jen pro čtení
type: docs
weight: 30
url: /cs/androidjava/read-only-presentation/
keywords:
- jen pro čtení
- chránit prezentaci
- zabránit editaci
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides pro Android přes Java, což nabízí přesné náhledy snímků bez úpravy vašich prezentací."
---
## **Úvod**

V PowerPoint 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení jen pro čtení můžete použít, chcete‑li chránit prezentaci, když

- chcete zabránit neúmyslným úpravám a uchovat obsah své prezentace v bezpečí. 
- chcete upozornit ostatní, že poskytnutá prezentace je konečná verze. 

Po výběru možnosti **Always Open Read-Only** pro prezentaci uvidí uživatelé při jejím otevření doporučení **Read-Only** a mohou vidět zprávu v tomto tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor tak, aby se otevřel jen pro čtení.*

Doporučení **Read-Only** je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon k jeho odstranění, než jsou povoleni prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to sdělit zdvořile, může být doporučení **Read-Only** pro vás vhodnou volbou. 

> Pokud se prezentace s ochranou **Read-Only** otevře ve starší verzi Microsoft PowerPointu, která nedělá podporu nově zavedené funkce, doporučení **Read-Only** se ignoruje (prezentace se otevře normálně).

## **Použít režim jen pro čtení**

Aspose.Slides pro Android přes Java umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód vám ukáže, jak nastavit prezentaci na **Read-Only** v Javě pomocí Aspose.Slides:

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

**Poznámka**: Doporučení **Read-Only** má za cíl pouze odradit od úprav nebo zabránit neúmyslným změnám PowerPointové prezentace. Pokud se motivovaná osoba—která ví, co dělá—rozhodne prezentaci upravit, může nastavení **Read-Only** snadno odstranit. Pokud skutečně potřebujete zabránit neautorizovaným úpravám, je lepší použít [přísnější ochrany zahrnující šifrování a hesla](https://docs.aspose.com/slides/cs/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **Často kladené otázky**

### Jak se liší „Read-Only recommended“ od plné ochrany heslem?

„Read-Only recommended“ pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obejít. [Ochrana heslem](/slides/cs/androidjava/password-protected-presentation/) skutečně omezuje otevírání nebo úpravy a je vhodná, když potřebujete reálné bezpečnostní kontroly.

### Lze „Read-Only recommended“ spojit s vodoznaky, aby se ještě více odrazovaly úpravy?

Ano. Doporučení lze spojit s [vodoznaky](/slides/cs/androidjava/watermark/) jako vizuálním odstrašujícím prostředkem; jsou to samostatné mechanismy a dobře spolupracují.

### Může makro nebo externí nástroj soubor stále upravovat, když je doporučení povoleno?

Ano. Doporučení neblokuje programové změny. Pro zamezení automatických úprav použijte [hesla a šifrování](/slides/cs/androidjava/password-protected-presentation/).

### Jak se „Read-Only recommended“ vztahuje k metodám „isEncrypted“ a „isWriteProtected“?

Jedná se o odlišné signály. „Read-Only recommended“ je měkký, volitelný podnět; [isWriteProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) a [isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.