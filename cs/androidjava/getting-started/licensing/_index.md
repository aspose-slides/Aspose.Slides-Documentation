---
title: Licencování
type: docs
weight: 90
url: /cs/androidjava/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- použít licenci
- ověřit licenci
- soubor licence
- zkušební verze
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro Android via Java. Zajistěte nepřetržitý přístup k plným funkcím pomocí našeho průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v režimu zkušební verze nebo s platnou licencí. Zkušební verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává při otevření nebo uložení prezentací vodoznak „evaluation“ a omezuje extrakci textu na jeden snímek.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licence může být načtena ze souboru, proudu nebo vloženého zdroje pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence správně aplikována.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="primary" %}} 

Můžete si stáhnout zkušební verzi **Aspose.Slides for Android via Java** z její [stránky ke stažení](https://releases.aspose.com/slides/cs/androidjava/). Zkušební verze poskytuje stejné funkce jako licencovaná verze produktu. Balíček zkušební verze je stejný jako zakoupený balíček. Zkušební verze se jednoduše stane licencovanou poté, co do ní přidáte několik řádků kódu (pro aplikaci licence).

Jakmile budete s vyhodnocením **Aspose.Slides** spokojeni, můžete [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme projít různé typy předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose obsahuje roční předplatné s bezplatnou aktualizací na nové verze nebo opravy během období předplatného. Uživatelé s licencovanými produkty (nebo i se zkušebními verzemi) získají bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení zkušební verze**

* Zatímco zkušební verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, vkládá při otevření a uložení dokumentu vodoznak „evaluation“ v horní části.
* Při extrakci textu z prezentačních snímků je omezení na jeden snímek.

{{% alert color="primary" %}} 

Chcete-li testovat Aspose.Slides bez omezení, můžete požádat o **30denní dočasnou licenci**. Více informací naleznete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**

* Zkušební verze se stane licencovanou poté, co zakoupíte licenci a přidáte několik řádků kódu (pro aplikaci licence).
* Licence je prostý textový soubor XML, který obsahuje podrobnosti jako název produktu, počet vývojářů, na které je licence udělena, datum vypršení předplatného atd.
* Soubor licence je digitálně podepsaný, takže jej nesmíte měnit. I neúmyslné přidání dalšího řádku do obsahu souboru jej zneplatní.
* Aspose.Slides for Android via Java se obvykle pokouší najít licenci v těchto umístěních:
  * Explicitní cesta
  * Složka obsahující Aspose.Slides.jar
* Aby se předešlo omezením spojeným se zkušební verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licenci je potřeba nastavit jen jednou za aplikaci nebo proces.

## **Aplikace licence**

Licence může být načtena ze **souboru** nebo **proudu**.

{{% alert color="primary" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/) pro operace s licencí.

{{% /alert %}} 

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides jen od verze 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **Soubor**

Nejjednodušší metoda nastavení licence vyžaduje umístit soubor licence do složky obsahující Aspose.Slides.jar nebo do jaru vaší aplikace.

Tento Java kód ukazuje, jak nastavit soubor licence:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví cestu k souboru licence
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Pokud umístíte soubor licence do jiného adresáře, při volání metody [SetLicense](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) musí být název souboru licence na konci zadané explicitní cesty stejný jako název vašeho souboru licence.

Například můžete změnit název souboru licence na *Aspose.Slides.Android.via.Java.lic.xml*. Pak ve svém kódu musíte předat cestu k souboru (končící na *Aspose.Slides.Android.via.Java.lic.xml*) metodě [SetLicense](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Proud**

Licence může být načtena z proudu. Tento Java kód ukazuje, jak aplikovat licenci z proudu:

``` java
// Vytváří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastavuje licenci pomocí proudu
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Ověření licence**

Pro kontrolu, zda byla licence správně nastavena, ji můžete ověřit. Tento Java kód ukazuje, jak ověřit licenci:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpečnost vlákna**

{{% alert title="Poznámka" color="warning" %}} 

Metoda [SetLicense](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) není bezpečná pro více vláken. Pokud je tato metoda volána současně z mnoha vláken, můžete chtít použít synchronizační primitiva (např. zámek), aby se předešlo problémům. 

{{% /alert %}}

## **Často kladené otázky**

**Mohu aplikovat licenci v úplně offline prostředí (bez přístupu k internetu)?**

Ano. Ověření licence probíhá lokálně pomocí souboru licence; připojení k internetu není vyžadováno.

**Co se stane po uplynutí ročního předplatného? Přestane knihovna fungovat?**

Ne. Licence je trvalá: můžete i nadále používat verze vydané před datem ukončení předplatného; jen nebudete mít oprávnění používat novější vydání bez obnovení.