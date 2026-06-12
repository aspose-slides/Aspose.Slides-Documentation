---
title: Uložení prezentací v režimu jen pro čtení pomocí JavaScriptu
linktitle: Prezentace jen pro čtení
type: docs
weight: 30
url: /cs/nodejs-java/read-only-presentation/
keywords:
- jen pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint v režimu jen pro čtení pomocí Aspose.Slides pro Node.js přes Java, což nabízí přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení jen pro čtení můžete chtít použít k ochraně prezentace, když

- Chcete zabránit neúmyslným úpravám a udržet obsah své prezentace v bezpečí. 
- Chcete upozornit ostatní, že poskytnutá prezentace je finální verzí. 

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když uživatelé otevřou prezentaci, uvidí doporučení **Read-Only** a mohou vidět zprávu v tomto tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor tak, aby se otevíral jen pro čtení.*

Doporučení **Read-Only** je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon k jeho odebrání, než jim bude umožněno prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to sdělit slušným způsobem, může být doporučení **Read-Only** pro vás dobrá volba. 

> Pokud je prezentace s ochranou **Read-Only** otevřena ve starší aplikaci Microsoft PowerPoint, která nově zavedenou funkci nepodporuje, bude doporučení **Read-Only** ignorováno (prezentace se otevře normálně).

## **Aplikovat režim jen pro čtení**

Aspose.Slides pro Node.js via Java vám umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód vám ukáže, jak nastavit prezentaci na **Read-Only** v JavaScriptu pomocí Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Poznámka**: Doporučení **Read-Only** je určeno pouze k odrazení úprav nebo zastavení uživatelů před neúmyslnými změnami v PowerPoint prezentaci. Pokud se motivovaná osoba—která ví, co dělá—rozhodne vaši prezentaci upravit, může nastavení Read-Only snadno odstranit. Pokud opravdu potřebujete zabránit neoprávněným úpravám, je lepší použít [přísnější ochranu, která zahrnuje šifrování a hesla](https://docs.aspose.com/slides/cs/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **Často kladené otázky**

**Jak se liší 'Read-Only recommended' od úplné ochrany heslem?**

'Read-Only recommended' pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obejít. [Ochrana heslem](/slides/cs/nodejs-java/password-protected-presentation/) skutečně omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečná bezpečnostní opatření.

**Lze 'Read-Only recommended' kombinovat s vodoznaky k dalšímu odrazení úprav?**

Ano. Doporučení lze spojit s [vodoznaky](/slides/cs/nodejs-java/watermark/) jako vizuálním odstrašujícím prostředkem; jsou to samostatné mechanismy a dobře spolu fungují.

**Může makro nebo externí nástroj stále soubor modifikovat, když je doporučení povoleno?**

Ano. Doporučení neblokuje programové změny. Pro zabránění automatickým úpravám použijte [hesla a šifrování](/slides/cs/nodejs-java/password-protected-presentation/).

**Jak se 'Read-Only recommended' vztahuje k příznakům 'IsEncrypted' a 'IsWriteProtected'?**

Jedná se o odlišné signály. 'Read-Only recommended' je měkká, volitelná výzva; [isWriteProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) a [isEncrypted](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/isencrypted/) označují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.