---
title: Licencování
type: docs
weight: 90
url: /cs/java/licensing/
keywords:
- licence
- dočasná licence
- nastavení licence
- použít licenci
- ověřit licenci
- soubor licence
- evaluační verze
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Používejte, spravujte a řešte problémy s licencemi v Aspose.Slides pro Java. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho krok za krokem průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v evaluačním režimu nebo s platnou licencí. Evaluační verze poskytuje stejnou funkčnost jako licencovaná verze, ale při otevření nebo uložení prezentací přidává evaluační vodoznak a omezuje extrakci textu na jeden snímek.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého zdroje pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence použita správně.

## **Vyzkoušet Aspose.Slides**

{{% alert color="info" %}} 

Evaluační verzi **Aspose.Slides for Java** si můžete stáhnout ze své [download page](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Evaluační verze poskytuje stejné funkce jako licencovaná verze produktu. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše stane licencovanou poté, co do ní přidáte několik řádků kódu (pro aplikaci licence).

Jakmile budete s evaluační verzí **Aspose.Slides** spokojeni, můžete [purchase a license](https://purchase.aspose.com/buy). Doporučujeme vám projít různé typy předplatného. Pokud máte otázky, obraťte se na prodejní tým Aspose.

Každá licence Aspose obsahuje roční předplatné na bezplatné aktualizace na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty (nebo dokonce s evaluačními verzemi) získají bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení evaluační verze**

* Zatímco evaluační verze Aspose.Slides (bez specifikované licence) poskytuje plnou funkčnost produktu, při operacích otevření a uložení vloží evaluační vodoznak na vrchol dokumentu.
* Při extrakci textu z prezentačních snímků jste omezeni na jeden snímek.

{{% alert color="info" %}} 

Chcete-li otestovat Aspose.Slides bez omezení, můžete požádat o **30denní dočasnou licenci**. Další informace naleznete na stránce [How to get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**

* Evaluační verze se stane licencovanou poté, co zakoupíte licenci a do ní přidáte několik řádků kódu (pro aplikaci licence).
* Licence je prostý textový soubor XML, který obsahuje údaje jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a podobně.
* Soubor licence je digitálně podepsaný, takže jej nesmíte měnit. I neúmyslné přidání dalšího konce řádku do obsahu souboru licenci zneplatní.
* Aspose.Slides pro Java obvykle hledá licenci na těchto místech:
  * Výslovná cesta
  * Složka obsahující Aspose.Slides.jar
* Abyste se vyhnuli omezením spojeným s evaluační verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licenci je potřeba nastavit jen jednou za aplikaci nebo proces.

{{% alert color="info" %}} 

Můžete se podívat na [Metered Licensing](/slides/cs/java/metered-licensing/).

{{% /alert %}} 


## **Aplikace licence**

C licenci lze načíst ze **souboru** nebo **proudu**.

{{% alert color="info" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License) pro operace s licencemi.

{{% /alert %}} 

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides pouze ve verzi 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **Soubor**

Nejjednodušší metoda nastavení licence vyžaduje umístit soubor licence do složky obsahující Aspose.Slides.jar nebo jar vašeho projektu.

Tento Java kód vám ukazuje, jak nastavit soubor licence:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví cestu k souboru licence
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Pokud soubor licence umístíte do jiného adresáře, při volání metody [SetLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License#setLicense-java.lang.String-) musí být název souboru licence na konci zadané explicitní cesty stejný jako váš soubor licence.

Příklad: můžete změnit název souboru licence na *Aspose.Slides.Java.lic.xml*. Poté ve vašem kódu musíte předat cestu k souboru (končící na *Aspose.Slides.Java.lic.xml*) metodě [SetLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Proud**

Můžete načíst licenci z proudu. Tento Java kód vám ukazuje, jak aplikovat licenci z proudu:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví licenci pomocí proudu
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Při používání Aspose.Slides pro PHP přes Java můžete nastavit licenci prostřednictvím PHP/Java mostu. Tento most umožňuje používat Java třídy v PHP syntaxi. Další informace naleznete na [License in PHP](/slides/cs/php-java/licensing/).

## **Validace licence**

Aby bylo možné zkontrolovat, zda byla licence nastavena správně, můžete ji ověřit. Tento Java kód vám ukazuje, jak licence ověřit:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Bezpečnost vláken**

{{% alert title="Note" color="warning" %}} 

Metoda [SetLicense](https://reference.aspose.com/slides/cs/java/com.aspose.slides/License#setLicense-java.io.InputStream-) není bezpečná pro více vláken. Pokud je tato metoda volána současně z více vláken, můžete chtít použít synchronizační primitiva (např. zámek), abyste se vyhnuli problémům. 

{{% /alert %}}

## **Často kladené otázky**

### Mohu aplikovat licenci v kompletně offline prostředí (bez přístupu k internetu)?

Ano. Ověření licence probíhá lokálně pomocí souboru licence; není vyžadováno žádné internetové připojení.

### Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete i nadále používat verze vydané před datem konce vašeho předplatného; jen nebudete mít nárok na novější verze bez obnovení.