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
description: "Aplikujte, spravujte a odstraňujte problémy s licencemi v Aspose.Slides pro Java. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v evaluačním režimu nebo s platnou licencí. Evaluační verze poskytuje stejnou funkcionalitu jako licencovaná verze, ale přidává vodotisk „evaluation“ při otevírání nebo ukládání prezentací a omezuje extrakci textu na jeden snímek.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého zdroje pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence správně aplikována.

## **Evaluační verze Aspose.Slides**

{{% alert color="primary" %}} 

Evaluační verzi **Aspose.Slides for Java** si můžete stáhnout z její [stánky ke stažení](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Evaluační verze poskytuje stejné funkce jako licencovaná verze produktu. Evaluační balíček je stejný jako zakoupený balíček. Po přidání několika řádků kódu (pro aplikaci licence) se evaluační verze jednoduše stane licencovanou.

Až budete s evaluační verzí **Aspose.Slides** spokojeni, můžete si [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme projít různé typy předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose obsahuje jednoleté předplatné na bezplatné aktualizace na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty (nebo i s evaluačními verzemi) získají bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení evaluační verze**

* Zatímco evaluační verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, vkládá vodotisk evaluační verze v horní části dokumentu při otevření i uložení. 
* Při extrakci textu z prezentací jste omezeni na jeden snímek.

{{% alert color="primary" %}} 

Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Více informací najdete na stránce [How to get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**

* Evaluační verze se stane licencovanou poté, co zakoupíte licenci a přidáte několik řádků kódu (pro aplikaci licence).
* Licence je prostý textový XML soubor, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a podobně. 
* Soubor licence je digitálně podepsán, takže jej nesmíte měnit. I neúmyslné přidání dalšího řádku do obsahu souboru jej zneplatní.
* Aspose.Slides for Java obvykle hledá licenci na těchto místech:
  * Explicitní cesta
  * Složka obsahující Aspose.Slides.jar
* Aby se předešlo omezením spojeným s evaluační verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licenci nastavíte jen jednou na aplikaci nebo proces.

{{% alert color="primary" %}} 

Můžete si také prohlédnout [Metered Licensing](/slides/cs/java/metered-licensing/).

{{% /alert %}} 


## **Aplikace licence**

Licence může být načtena ze **souboru** nebo **proudu**.

{{% alert color="primary" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License) pro operace s licencí.

{{% /alert %}} 

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides pouze od verze 21.4 a novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **Soubor**

Nejjednodušší metoda nastavení licence vyžaduje umístění souboru licence do složky obsahující Aspose.Slides.jar nebo do JAR souboru vaší aplikace.

Tento Java kód ukazuje, jak nastavit soubor licence:

``` java
// Vytváří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastavuje cestu k souboru licence
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Pokud soubor licence umístíte do jiného adresáře, při volání metody [SetLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License#setLicense-java.lang.String-) musí být název souboru licence na konci zadané explicitní cesty stejný jako váš soubor licence.

Například můžete změnit název souboru licence na *Aspose.Slides.Java.lic.xml*. Pak ve svém kódu musíte předat cestu k souboru (končící na *Aspose.Slides.Java.lic.xml*) metodě [SetLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Průtok**

Licence může být načtena z proudu. Tento Java kód ukazuje, jak aplikovat licenci z proudu:

``` java
// Vytváří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastavuje licenci pomocí proudu
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Pokud používáte Aspose.Slides for PHP přes Java, můžete nastavit licenci prostřednictvím PHP/Java mostu. Tento most umožňuje používat Java třídy v PHP syntaxi. Další informace najdete v článku [License in PHP](/slides/cs/php-java/licensing/).

## **Ověření licence**

Pro kontrolu, zda byla licence správně nastavena, ji můžete ověřit. Tento Java kód ukazuje, jak licenci ověřit:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpečnost při více vláknech**

{{% alert title="Note" color="warning" %}} 

Metoda [SetLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License#setLicense-java.io.InputStream-) není bezpečná pro více vláken. Pokud má být tato metoda volána současně z mnoha vláken, můžete chtít použít synchronizační primitiva (např. zámek), abyste předešli problémům. 

{{% /alert %}}

## **Často kladené otázky**

**Mohu aplikovat licenci v zcela offline prostředí (bez přístupu k internetu)?**

Ano. Ověření licence probíhá lokálně pomocí souboru licence; není vyžadováno žádné internetové připojení.

**Co se stane po vypršení jednorázového ročního předplatného? Přestane knihovna fungovat?**

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem konce vašeho předplatného; pouze nebudete mít nárok na novější vydání bez obnovení předplatného.