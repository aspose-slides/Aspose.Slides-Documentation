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
- evaluační verze
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro Android via Java. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho průvodce licencováním."
---
## **Přehled**

Aspose.Slides může být používán v evaluačním režimu nebo s platnou licencí. Evaluační verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává evaluační vodoznak na každou snímku každé prezentace, kterou uloží, a zkracuje text, který váš kód čte z prezentací.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého prostředku pomocí třídy [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/). Článek také ukazuje, jak ověřit, zda byla licence aplikována správně.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="info" title="Poznámka" %}}
Můžete si stáhnout evaluační verzi **Aspose.Slides for Android via Java** z její [stránky ke stažení](https://releases.aspose.com/slides/androidjava/). Evaluační verze poskytuje stejné funkce jako licencovaná verze produktu. Evaluační balíček je stejný jako zakoupený balíček. Evaluační verze se jednoduše stane licencovanou poté, co do ní přidáte několik řádků kódu (pro aplikaci licence).

Jakmile budete s evaluační verzí **Aspose.Slides** spokojeni, můžete [zakoupit licenci](https://purchase.aspose.com/pricing/slides/android-java/). Doporučujeme projít různé typy předplatného. Pokud máte otázky, kontaktujte prodejní tým Aspose.

Každá licence Aspose zahrnuje jednosléduční předplatné s bezplatnými upgradey na nové verze nebo opravy vydané během období předplatného. Uživatelé s licencovanými produkty (nebo dokonce s evaluačními verzemi) získají bezplatnou a neomezenou technickou podporu.
{{% /alert %}} 

**Omezení evaluační verze**

* Evaluační verze (bez specifikované licence) poskytuje plnou funkčnost produktu, ale přidává evaluační vodoznakový textový rámeček na každou snímku každé prezentace, kterou uloží.
* Text, který váš kód čte z prezentace, je zkrácen na několik prvních znaků, následovaný upozorněním na omezení evaluační verze. Text, který váš kód zapisuje, je uložen v plné délce.

{{% alert color="info" title="Poznámka" %}}
Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Více informací najdete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licencování v Aspose.Slides**

* Evaluační verze se stane licencovanou poté, co zakoupíte licenci a přidáte několik řádků kódu (pro aplikaci licence).
* Licence je prostý textový XML soubor, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a podobně.
* Soubor licence je digitálně podepsán, takže jej nesmíte měnit. I nepřímé přidání dalšího konce řádku do obsahu souboru jej zneplatní.
* Aspose.Slides for Android via Java se typicky snaží najít licenci v těchto místech:
  * Výslovná cesta
  * Složka obsahující Aspose.Slides.jar
* Aby se předešlo omezením spojeným s evaluační verzí, musíte nastavit licenci před použitím **Aspose.Slides**. Licence se nastavuje jednou na aplikaci nebo proces.

## **Použití licence**

Licence může být načtena ze **souboru** nebo **proudu**.

{{% alert color="info" title="Poznámka" %}}
Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) pro operace s licencí.
{{% /alert %}} 

{{% alert color="warning" title="Varování" %}}
Nové licence mohou aktivovat Aspose.Slides pouze s verzí 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.
{{% /alert %}}

### **Soubor**

Nejjednodušší metoda nastavení licence vyžaduje umístění souboru licence do složky obsahující Aspose.Slides.jar nebo do jar souboru vaší aplikace.

{{% alert color="info" title="Poznámka" %}}
Na Androidu jsou knihovna a vaše aplikace zabaleny do APK, takže neexistuje složka obsahující JAR soubor knihovny a relativní cesta jako *Aspose.Slides.Android.via.Java.lic* neukazuje na soubor ve vaší aplikaci. Přidejte soubor licence do assetů vaší aplikace a načtěte jej z proudu, jak je ukázáno v [Stream z aktiv aplikace](#stream-from-app-assets).
{{% /alert %}}

Tento Java kód ukazuje, jak nastavit soubor licence:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví cestu k souboru licence
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Varování" %}}
Pokud soubor licence umístíte do jiného adresáře, při volání metody [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) musí být název souboru licence na konci zadané cesty stejný jako název vašeho souboru licence.

Například můžete změnit název souboru licence na *Aspose.Slides.Android.via.Java.lic.xml*. Pak ve svém kódu musíte předat cestu k souboru (končící *Aspose.Slides.Android.via.Java.lic.xml*) metodě [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).
{{% /alert %}}

### **Stream**

Licenci můžete načíst z proudu. Tento Java kód ukazuje, jak aplikovat licenci z proudu:

``` java
// Vytvoří instanci třídy License
com.aspose.slides.License license = new com.aspose.slides.License();

// Nastaví licenci pomocí proudu
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Stream z aktiv aplikace**

V Android aplikaci umístěte soubor licence do složky *assets* modulů aplikace, *app/src/main/assets*, aby byl zabalen do APK. Otevřete soubor metodou [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) a předáte proud metodě [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). Kód běží uvnitř `Activity`, například v metodě `onCreate`, předtím než aplikace použije Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Název souboru předaný metodě [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) je relativní k složce *assets*. Pokud soubor tam není, kód zaznamená chybu a Aspose.Slides zůstane v evaluačním režimu. Pro kontrolu, zda byla licence aplikována, viz [Ověření licence](#validating-a-license).

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

## **Bezpečnost vláken**

{{% alert color="warning" title="Varování" %}}
Metoda [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) není bezpečná pro více vláken. Pokud má být tato metoda volána současně z mnoha vláken, můžete chtít použít synchronizační primitivy (např. zámek), abyste se vyhnuli problémům.
{{% /alert %}}

## **Často kladené otázky**

### Můžu aplikovat licenci v zcela offline prostředí (bez přístupu k internetu)?

Ano. Ověření licence se provádí lokálně pomocí souboru licence; není vyžadováno žádné připojení k internetu.

### Co se stane po vypršení jednoslédučního předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem konce vašeho předplatného; jen nebudete mít nárok na novější verze bez obnovení předplatného.