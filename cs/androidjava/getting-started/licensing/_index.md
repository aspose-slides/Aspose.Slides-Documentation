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
- licenční soubor
- hodnotící verze
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro Android via Java. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze použít v režimu hodnocení nebo s platnou licencí. Hodnotící verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává vodotisk hodnocení při otevření nebo uložení prezentací a omezuje extrakci textu na jeden snímek.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého prostředku pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence aplikována správně.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="info" %}} 

Můžete si stáhnout hodnotící verzi **Aspose.Slides for Android via Java** z její [stránky ke stažení](https://releases.aspose.com/slides/cs/androidjava/). Hodnotící verze poskytuje stejné funkce jako licencovaná verze produktu. Balíček pro hodnocení je stejný jako zakoupený balíček. Hodnotící verze se jednoduše stane licencovanou po přidání několika řádků kódu (pro aplikaci licence).

Jakmile budete s hodnocením **Aspose.Slides** spokojeni, můžete [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme projít různé typy předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose obsahuje roční předplatné pro bezplatné aktualizace na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty (nebo i s hodnotícími verzemi) získávají bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení hodnotící verze**

* Přestože hodnotící verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, vkládá vodotisk hodnocení v horní části dokumentu při operacích otevření a uložení. 
* Při extrakci textu z prezentací jste omezeni na jeden snímek.

{{% alert color="info" %}} 

Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Viz stránka [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license) pro více informací.

{{% /alert %}}

## **Licencování v Aspose.Slides**

* Hodnotící verze se stane licencovanou po zakoupení licence a přidání několika řádků kódu (pro aplikaci licence).
* Licence je prostý textový XML soubor, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licence udělena, datum vypršení předplatného a další. 
* Soubor licence je digitálně podepsán, proto jej nesmíte měnit. I neúmyslné přidání nového řádku do obsahu souboru jej zneplatní.
* Aspose.Slides for Android via Java se obvykle pokouší najít licenci na těchto místech:
  * Explicitní cesta
  * Složka obsahující Aspose.Slides.jar
* Abyste se vyhnuli omezením spojeným s hodnotící verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licenci je třeba nastavit pouze jednou na aplikaci nebo proces.

## **Aplikace licence**

Licence může být načtena ze **souboru** nebo **proudu**.

{{% alert color="info" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/) pro operace související s licencováním.

{{% /alert %}} 

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides pouze od verze 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **Soubor**

Nejsnazší metoda nastavení licence vyžaduje umístit licenční soubor do složky obsahující Aspose.Slides.jar nebo do jar souboru vaší aplikace.

Tento Java kód ukazuje, jak nastavit licenční soubor:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví cestu k licenčnímu souboru
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Pokud umístíte licenční soubor do jiného adresáře, při volání metody [SetLicense](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) musí být název licenčního souboru na konci zadané explicitní cesty stejný jako váš licenční soubor.

Například můžete změnit název licenčního souboru na *Aspose.Slides.Android.via.Java.lic.xml*. Pak ve svém kódu musíte předat cestu k souboru (končící na *Aspose.Slides.Android.via.Java.lic.xml*) metodě [SetLicense](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Průtok**

Licence může být načtena z proudu. Tento Java kód ukazuje, jak aplikovat licenci z proudu:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví licenci přes proud
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Ověření licence**

Pro kontrolu, zda byla licence nastavena správně, ji můžete ověřit. Tento Java kód ukazuje, jak ověřit licenci:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpečnost při více vláknech**

{{% alert title="Poznámka" color="warning" %}} 

Metoda [SetLicense](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) není bezpečná pro více vláken. Pokud je tato metoda volána současně z mnoha vláken, můžete použít synchronizační primitiva (např. zámek), abyste se vyhnuli problémům. 

{{% /alert %}}

## **Často kladené otázky**

### Mohu aplikovat licenci v úplně offline prostředí (bez přístupu k internetu)?

Ano. Ověření licence probíhá lokálně pomocí licenčního souboru; není vyžadováno žádné připojení k internetu.

### Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem vypršení předplatného; jen nebudete mít nárok na novější vydání bez obnovení předplatného.