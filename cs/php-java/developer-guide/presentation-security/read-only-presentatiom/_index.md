---
title: Uložit prezentace v režimu jen pro čtení pomocí PHP
linktitle: Prezentace jen pro čtení
type: docs
weight: 30
url: /cs/php-java/read-only-presentation/
keywords:
- jen pro čtení
- chránit prezentaci
- zabránit úpravám
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Načtěte a uložte soubory PowerPoint (PPT, PPTX) v režimu jen pro čtení pomocí Aspose.Slides pro PHP, což poskytuje přesné náhledy snímků bez úpravy vašich prezentací."
---
## **Úvod**

V PowerPointu 2019 společnost Microsoft představila nastavení **Always Open Read-Only** jako jednu z možností, které uživatelé mohou použít k ochraně svých prezentací. Toto nastavení Read-Only můžete chtít použít k ochraně prezentace, když

- Chcete zabránit neúmyslným úpravám a udržet obsah své prezentace v bezpečí. 
- Chcete upozornit lidi, že poskytnutá prezentace je finální verzí. 

Po výběru možnosti **Always Open Read-Only** pro prezentaci, když uživatelé otevřou prezentaci, uvidí doporučení **Read-Only** a mohou vidět zprávu v tomto tvaru: *Aby se zabránilo neúmyslným změnám, autor nastavil tento soubor tak, aby se otevíral jen pro čtení.*

Doporučení Read-Only je jednoduchý, ale účinný odstrašující prostředek, který odrazuje od úprav, protože uživatelé musí provést úkon, aby jej odstranili, než jsou povoleni prezentaci upravovat. Pokud nechcete, aby uživatelé prováděli změny v prezentaci, a chcete jim to zdvořile sdělit, může být doporučení Read-Only pro vás vhodnou volbou. 

> Pokud je prezentace s ochranou **Read-Only** otevřena ve starší aplikaci Microsoft PowerPoint, která tuto nedávno zavedenou funkci nepodporuje, doporučení **Read-Only** se ignoruje (prezentace se otevře normálně).

## **Použít režim Read-Only**

Aspose.Slides for PHP via Java vám umožňuje nastavit prezentaci na **Read-Only**, což znamená, že uživatelé (po otevření prezentace) uvidí doporučení **Read-Only**. Tento ukázkový kód vám ukazuje, jak nastavit prezentaci na **Read-Only** pomocí Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Note**: Doporučení **Read-Only** je určeno k odrazení úprav nebo zastavení neúmyslných změn v PowerPoint prezentaci. Pokud se motivovaný člověk – který ví, co dělá – rozhodne vaši prezentaci upravit, může snadno nastavení Read-Only odstranit. Pokud opravdu potřebujete zabránit neoprávněným úpravám, je lepší použít [přísnější ochrany zahrnující šifrování a hesla](https://docs.aspose.com/slides/cs/php-java/password-protected-presentation/).

{{% /alert %}} 

## **Často kladené otázky**

**Jak se 'Read-Only recommended' liší od úplné ochrany heslem?**

'Read-Only recommended' pouze zobrazuje návrh otevřít soubor v režimu jen pro čtení a lze jej snadno obejít. [Ochrana heslem](/slides/cs/php-java/password-protected-presentation/) skutečně omezuje otevírání nebo úpravy a je vhodná, když potřebujete skutečnou bezpečnostní kontrolu.

**Lze 'Read-Only recommended' kombinovat s vodoznaky pro další odrazení úprav?**

Ano. Doporučení lze spojit s [vodoznaky](/slides/cs/php-java/watermark/) jako vizuálním odstrašujícím prostředkem; jsou to samostatné mechanismy a dobře spolu fungují.

**Může makro nebo externí nástroj stále soubor upravit, když je doporučení povoleno?**

Ano. Doporučení neblokuje programové změny. Pro zabránění automatickým úpravám použijte [hesla a šifrování](/slides/cs/php-java/password-protected-presentation/).

**Jak se 'Read-Only recommended' vztahuje k metodám 'isEncrypted' a 'isWriteProtected'?**

Jedná se o odlišné signály. 'Read-Only recommended' je měkká, volitelná výzva; [isWriteProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/iswriteprotected/) a [isEncrypted](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/isencrypted/) indikují skutečná omezení zápisu nebo čtení, která závisí na heslech nebo šifrování.