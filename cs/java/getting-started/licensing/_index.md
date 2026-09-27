---
title: Licencování
type: docs
weight: 90
url: /cs/java/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- použít licenci
- ověřit licenci
- soubor licence
- evaluační verze
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Použijte, spravujte a řešte problémy s licencemi v Aspose.Slides pro Java. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho krok za krokem průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v evaluačním režimu nebo s platnou licencí. Evaluační verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává evaluační vodoznak na každý snímek každé prezentace, kterou uloží, a ořezává text, který váš kód čte prostřednictvím API.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak použít licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého zdroje pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence použita správně.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="info" title="Note" %}}
Můžete si stáhnout evaluační verzi **Aspose.Slides for Java** z její [stahovací stránky](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Evaluační verze poskytuje stejné funkce jako licencovaná verze produktu. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše stane licencovanou po přidání několika řádků kódu (k použití licence).

Jakmile budete spokojeni s evaluační verzí **Aspose.Slides**, můžete [zakoupit licenci](https://purchase.aspose.com/pricing/slides/cs/java/). Doporučujeme projít různé typy předplatného. Pokud máte otázky, obraťte se na prodejní tým Aspose.

Každá licence Aspose obsahuje roční předplatné s bezplatnými aktualizacemi na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty (nebo i s evaluačními verzemi) získají bezplatnou a neomezenou technickou podporu.
{{% /alert %}} 

**Omezení evaluační verze**

* Evaluační verze (bez uvedené licence) poskytuje plnou funkčnost produktu, ale přidává textové pole s evaluačním vodoznakem na každý snímek každé prezentace, kterou uloží.
* Text, který váš kód čte prostřednictvím API, včetně textu, který právě nastavil, je oříznut na několik prvních znaků a následován upozorněním o omezení evaluační verze. Text, který váš kód zapisuje, je uložen v plné délce.

{{% alert color="info" title="Note" %}}
Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Více informací najdete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licencování v Aspose.Slides**

* Evaluační verze se stane licencovanou po zakoupení licence a přidání několika řádků kódu (k použití licence).
* Licence je běžný textový soubor XML, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence udělena, datum vypršení předplatného a podobně.
* Soubor licence je digitálně podepsán, takže ho nesmíte měnit. I neúmyslné přidání dalšího konce řádku do obsahu souboru jej zneplatní.
* Aspose.Slides for Java obvykle hledá licenci na následujících místech:
  * Explicitní cesta
  * Složka obsahující Aspose.Slides.jar
* Abyste se vyhnuli omezením spojeným s evaluační verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licenci je potřeba nastavit jen jednou na aplikaci nebo proces.

{{% alert color="info" title="Note" %}}
Možná budete chtít zobrazit [Metered Licensing](/slides/cs/java/metered-licensing/).
{{% /alert %}} 


## **Použití licence**

Licence může být načtena ze **souboru** nebo **proudu**.

{{% alert color="info" title="Note" %}}
Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/java/com.aspose.slides/license/) pro operace s licencemi.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Nové licence mohou aktivovat Aspose.Slides pouze od verze 21.4 a novějších. Starší verze používají jiný licenční systém a tyto licence nepoznají.
{{% /alert %}}

### **Soubor**

Nejjednodušší metoda nastavení licence vyžaduje umístit soubor licence do složky obsahující Aspose.Slides.jar nebo jar vaší aplikace.

Tento Java kód ukazuje, jak nastavit soubor licence:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví cestu k souboru licence
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Pokud umístíte soubor licence do jiného adresáře, při volání metody [setLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/license/#setLicense-java.lang.String-) musí být název souboru licence na konci zadané cesty stejný jako název vašeho souboru licence.

Například můžete změnit název souboru licence na *Aspose.Slides.Java.lic.xml*. Poté ve vašem kódu musíte předat cestu k souboru (končící na *Aspose.Slides.Java.lic.xml*) metodě [setLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/license/#setLicense-java.lang.String-).
{{% /alert %}}

### **Proud**

Licence může být načtena z proudu. Tento Java kód ukazuje, jak použít licenci z proudu:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví licenci pomocí proudu
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Pokud používáte Aspose.Slides pro PHP prostřednictvím Javy, můžete licenci nastavit pomocí mostu PHP/Java. Tento most umožňuje používat Java třídy v syntaxi PHP. Více informací naleznete na stránce [License in PHP](/slides/cs/php-java/licensing/).

## **Ověření licence**

Pro kontrolu, zda byla licence nastavena správně, ji můžete ověřit. Tento Java kód ukazuje, jak ověřit licenci:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpečnost vlákna**

{{% alert color="warning" title="Warning" %}}
Metoda [setLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) není bezpečná pro více vláken. Pokud musí být tato metoda volána současně z více vláken, můžete použít synchronizační primitiva (např. zámek) k zabránění problémům.
{{% /alert %}}

## **Často kladené otázky**

### Mohu použít licenci v úplně offline prostředí (bez připojení k internetu)?

Ano. Ověření licence se provádí lokálně pomocí souboru licence; není vyžadováno žádné internetové připojení.

### Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete i nadále používat verze vydané před datem ukončení vašeho předplatného; jen nebudete mít nárok na novější vydání bez obnovení předplatného.