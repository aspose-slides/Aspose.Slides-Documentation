---
title: "Uložení prezentací v režimu jen pro čtení na Androidu"
linktitle: "Prezentace jen pro čtení"
type: docs
weight: 30
url: /cs/androidjava/read-only-presentation/
keywords:
- jen pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides for Android via Java, což poskytuje přesné náhledy snímků bez změny vašich prezentací."
---
## **Introduction**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení Read-Only můžete použít k ochraně prezentace, když

- chcete zabránit neúmyslným úpravám a udržet obsah své prezentace v bezpečí.  
- chcete upozornit ostatní, že poskytnutá prezentace je finální verzí.  

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když ji uživatelé otevřou, uvidí doporučení **Read-Only** a mohou vidět zprávu ve tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor k otevření jen pro čtení.*

Doporučení **Read-Only** je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést akci, aby jej odstranili, než budou moci prezentaci editovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete je o tom informovat zdvořilým způsobem, může být doporučení **Read-Only** pro vás dobrá volba.

> Pokud se prezentace s ochranou **Read-Only** otevře ve starší aplikaci Microsoft PowerPoint, která nedisponuje nově zavedenou funkcí, doporučení **Read-Only** bude ignorováno (prezentace se otevře normálně).

## **Apply Read-Only Mode**

Aspose.Slides for Android via Java umožňuje nastavit prezentaci jako **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód ukazuje, jak nastavit prezentaci jako **Read-Only** v Javě pomocí Aspose.Slides:

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

**Note**: Doporučení **Read-Only** je určeno pouze k odrazení úprav nebo zastavení neúmyslných změn v prezentaci PowerPoint. Pokud se motivovaná osoba – která ví, co dělá – rozhodne prezentaci upravit, může nastavení Read-Only snadno odstranit. Pokud opravdu potřebujete zabránit neautorizovaným úpravám, je lepší použít [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/cs/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Jak se liší ‘Read-Only recommended’ od úplné ochrany heslem?**

‘Read-Only recommended’ pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obejít. [Password protection](/slides/cs/androidjava/password-protected-presentation/) skutečně omezuje otevírání nebo úpravy a je vhodná, když potřebujete reálnou bezpečnostní kontrolu.

**Lze ‘Read-Only recommended’ kombinovat s vodoznaky, aby se ještě více odradily úpravy?**

Ano. Doporučení lze spárovat s [watermarks](/slides/cs/androidjava/watermark/) jako vizuálním odstrašujícím prostředkem; jsou to samostatné mechanismy a dobře spolu fungují.

**Může makro nebo externí nástroj stále soubor upravit, když je doporučení povoleno?**

Ano. Doporučení neblokuje programové změny. Pro zabránění automatizovaným úpravám použijte [passwords and encryption](/slides/cs/androidjava/password-protected-presentation/).

**Jak se ‘Read-Only recommended’ vztahuje k metodám ‘isEncrypted’ a ‘isWriteProtected’?**

Jedná se o odlišné signály. ‘Read-Only recommended’ je měkký, volitelný výzva; [isWriteProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) a [isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.