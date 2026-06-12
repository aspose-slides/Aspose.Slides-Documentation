---
title: Instala
type: docs
weight: 70
url: /cs/php-java/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- použít Aspose.Slides
- Instalace Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Rychle nainstalujte Aspose.Slides pro PHP přes Java. Podrobný průvodce, systémové požadavky a ukázky kódu - začněte dnes pracovat s prezentacemi PowerPoint!"
---
## **Přehled**

Tento článek vysvětluje, jak nainstalovat a nakonfigurovat Aspose.Slides pro PHP přes Java. Popisuje požadované nastavení prostředí, stažení knihovny přes Packagist, konfiguraci Apache Tomcat s PHP/Java Bridge a spuštění příkladu pro ověření instalace.

## **Nastavení prostředí**

1. Nainstalujte PHP 7, přidejte cestu k PHP do systémové proměnné `PATH` a v souboru `php.ini` nastavte `allow_url_include` na `On`.
2. Nainstalujte JRE 8. Nastavte proměnnou prostředí `JAVA_HOME` na cestu k nainstalovanému JRE.
3. Nainstalujte Apache Tomcat 8.0.

## **Stáhnutí Aspose.Slides pro PHP přes Java**

`packagist` je nejjednodušší způsob, jak stáhnout [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides).

Pro instalaci Aspose.Slides pomocí Packagist spusťte tento příkaz: 
```bash
   composer require aspose/slides
   ```

## **Konfigurace Apache Tomcat**

1. Stáhněte PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) z http://php-java-bridge.sourceforge.net/pjb/download.php a rozbalte soubor `JavaBridge.war` do složky `webapps` Tomcatu.
2. Spusťte službu Apache Tomcat.
3. Stáhněte [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/cs/php-java) a rozbalte jej do složky `aspose.slides`. Zkopírujte soubor `jar/aspose-slides-x.x-php.jar` do složky `webapps\JavaBridge\WEB-INF\lib`. Pokud používáte **PHP 8**, nahraďte původní `Java.inc` z PHP-Java Bridge souborom `Java.inc` ze `Java.inc.php8.zip`.
4. Restartujte službu Apache Tomcat.
5. Spusťte `example.php` ve složce `aspose.slides` příkazem:
```bash
   php example.php
   ```

## **Často kladené otázky**

**Jak mohu ověřit, že je Aspose.Slides integrováno správně?**

Sestavte svůj projekt, vytvořte prázdnou [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a uložte ji pod novým názvem. Pokud je soubor vytvořen bez vyhození výjimek, knihovna byla úspěšně integrována.

**Jak mohu omezit spotřebu paměti při zpracování velkých prezentací?**

Zvyšte limity paměti JVM jen na nezbytně nutnou výšku a v `finally` bloku uzavřete každou instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) pro okamžité uvolnění cache. Tím zabráníte chybám nedostatku paměti a udržíte celkovou spotřebu paměti během dávkových operací předvídatelnou.

**Mohu vyloučit nechtěné exportní formáty pro zmenšení konečné velikosti JAR?**

Aktuální vydání Aspose.Slides jsou distribuována jako jediné monolitické knihovny, takže není možné během sestavení zakázat konkrétní exportéry, jako jsou PDF nebo SVG.