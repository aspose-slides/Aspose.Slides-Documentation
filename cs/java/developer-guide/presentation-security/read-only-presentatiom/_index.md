---
title: Uložení prezentací v režimu jen pro čtení pomocí Javy
linktitle: Prezentace jen pro čtení
type: docs
weight: 30
url: /cs/java/read-only-presentation/
keywords:
- jen pro čtení
- ochrana prezentace
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides for Java, což nabízí přesné náhledy snímků bez změny vašich prezentací."
---
## **Úvod**

V PowerPoint 2019 Microsoft zavedl nastavení **Vždy otevřít jen pro čtení** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení jen pro čtení můžete použít k ochraně prezentace, když

- Chcete zabránit náhodným úpravám a udržet obsah prezentace v bezpečí. 
- Chcete upozornit ostatní, že poskytnutá prezentace je finální verze. 

Po výběru možnosti **Vždy otevřít jen pro čtení** pro prezentaci, když uživatelé prezentaci otevřou, uvidí doporučení **Pouze pro čtení** a mohou vidět zprávu ve tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor tak, aby byl otevírán jen pro čtení.*

Doporučení jen pro čtení je jednoduché, ale účinné odstrašování, které odrazuje od úprav, protože uživatelé musí provést úkon k jeho odstranění, než mohou prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci a chcete jim to sdělit slušným způsobem, pak může být doporučení jen pro čtení pro vás dobrá volba. 

> Pokud se prezentace s ochranou **Pouze pro čtení** otevře ve starší verzi Microsoft PowerPointu — která nepodporuje nedávno zavedenou funkci — doporučení **Pouze pro čtení** se ignoruje (prezentace se otevře normálně).

## **Použití režimu jen pro čtení**

Aspose.Slides for Java vám umožňuje nastavit prezentaci na **Pouze pro čtení**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Pouze pro čtení**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci na **Pouze pro čtení** v Javě pomocí Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Poznámka**: Doporučení **Pouze pro čtení** je zamýšleno jen jako odstrašování úprav nebo zastavení neúmyslných změn v PowerPoint prezentaci. Pokud motivovaná osoba — která ví, co dělá — se rozhodne vaši prezentaci upravit, může snadno odstranit nastavení Pouze pro čtení. Pokud opravdu potřebujete zabránit neoprávněným úpravám, je lepší použít [přísnější ochrany, které zahrnují šifrování a hesla](https://docs.aspose.com/slides/cs/java/password-protected-presentation/). 

{{% /alert %}} 

## **Často kladené otázky**

**Jak se liší „Doporučeno jen pro čtení“ od úplné ochrany heslem?**

„Doporučeno jen pro čtení“ pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a je snadno obejitelný. [Password protection](/slides/cs/java/password-protected-presentation/) ve skutečnosti omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečná bezpečnostní opatření.

**Lze kombinovat „Doporučeno jen pro čtení“ s vodoznaky pro další odstrašení úprav?**

Ano. Doporučení lze spojit s [watermarks](/slides/cs/java/watermark/) jako vizuálním odstrašením; jsou to samostatné mechanismy a dobře spolu fungují.

**Může makro nebo externí nástroj stále soubor upravit, když je doporučení povoleno?**

Ano. Doporučení neblokuje programové změny. Pro zabránění automatizovaným úpravám použijte [passwords and encryption](/slides/cs/java/password-protected-presentation/).

**Jak se „Doporučeno jen pro čtení“ vztahuje k metodám „isEncrypted“ a „isWriteProtected“?**

Jsou to různé signály. „Doporučeno jen pro čtení“ je měkká, volitelná výzva; [isWriteProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/protectionmanager/#isWriteProtected--) a [isEncrypted](https://reference.aspose.com/slides/cs/java/com.aspose.slides/protectionmanager/#isEncrypted--) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.