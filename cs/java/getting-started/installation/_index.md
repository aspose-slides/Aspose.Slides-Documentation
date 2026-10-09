---
title: Instalace
type: docs
weight: 70
url: /cs/java/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- používat Aspose.Slides
- instalace Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Nainstalujte Aspose.Slides pro Java z Maven repozitáře Aspose nebo jako soubor JAR, nastavte předpoklady pro Linux a ověřte instalaci pomocí prvního programu."
---
## **Přehled**

Tento článek vysvětluje, jak přidat Aspose.Slides for Java do projektu. Aspose.Slides for Java je publikován ve vlastní Maven repozitáři Aspose, nikoli v Maven Central, takže Maven projekt musí tento repozitář deklarovat. Můžete také stáhnout soubor JAR a přidat jej ručně do classpath. Obě cesty končí krátkým programem, který potvrzuje, že knihovna funguje.

Aspose.Slides for Java nevyžaduje Microsoft PowerPoint. Programově generuje potřebné soubory prezentací. Pro zobrazení vygenerovaných prezentací však můžete potřebovat Microsoft PowerPoint nebo jiný prohlížeč prezentací.

## **Požadavky**

- Java Development Kit (JDK). Projekt a příkazy v tomto článku vyžadují JDK 11 nebo novější. V JDK 11 program, který kontroluje instalaci, vypíše varování začínající „WARNING: An illegal reflective access operation has occurred“; nemá vliv na výsledek a lze jej ignorovat.
- [Apache Maven](https://maven.apache.org/install.html), pokud používáte Maven cestu.
- Na Linuxu knihovnu fontconfig a alespoň jedno nainstalované písmo. Viz [Linux](#linux).

## **Instalace z Maven repozitáře**

Aspose hostuje své Java knihovny ve svém vlastním [Maven repozitář](https://releases.aspose.com/java/repo/com/aspose/). Pro použití [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) v Maven projektu přidejte dva záznamy do vašeho *pom.xml*.

1. **Deklarujte Maven repozitář Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Přidejte závislost Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8` klasifikátor je vyžadován: vybírá Java SE sestavení knihovny. Nahraďte `26.10` nejnovější verzí uvedenou v [repozitáři](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Repoziář publikuje soubor SHA‑1 kontrolního součtu vedle každého JAR, který Maven ověří při stahování knihovny.

### **Zkontrolujte instalaci**

Pro kontrolu nastavení s novým projektem:

1. Vytvořte složku pro projekt a uložte do ní tento *pom.xml*:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.10</version>
               <classifier>jdk8</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Kromě repozitáře a závislosti tento *pom.xml* nastavuje verzi Javy pro kompilaci, názvu třídy, kterou spouští `mvn exec:java`, a upíná plugin kompilátoru, protože starší plugin, který některé instalace Maven používají ve výchozím nastavení, ignoruje nastavení `maven.compiler.release`.

2. Uložte první příklad z [Vytvořit prezentace](/slides/cs/java/create-presentation/) jako *src/main/java/HelloSlides.java*.

3. Ve složce projektu spusťte:

   ```bash
   mvn compile exec:java
   ```

Maven stáhne Aspose.Slides for Java, zkompiluje program a spustí jej. Program uloží *new_presentation.pptx* do složky projektu.

## **Použití souboru JAR bez Maven**

1. Stáhněte *aspose-slides-26.10-jdk8.jar* z [složky verze](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) v repozitáři. Pro jinou verzi otevřete její složku v [repozitáři](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) a stáhněte soubor končící na *-jdk8.jar*.

2. Uložte první příklad z [Vytvořit prezentace](/slides/cs/java/create-presentation/) jako *HelloSlides.java* do stejné složky jako soubor JAR.

3. V této složce spusťte:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK zkompiluje a spustí jediný zdrojový soubor a program uloží *new_presentation.pptx* do složky. Ve své aplikaci přidejte soubor JAR do classpath ve vašem nástroji pro sestavení nebo IDE.

## **Linux**

Aspose.Slides for Java používá podporu písem Java, která na Linuxu vyžaduje knihovnu fontconfig a alespoň jedno nainstalované písmo. Bez nich ukládání prezentace selže s chybou „Fontconfig head is null, check your fonts or fonts configuration“. Minimální serverové a kontejnerové obrazy mohou obojí postrádat; např. oficiální Ubuntu kontejnerový obraz neobsahuje žádné.

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Písma použité ve vašich prezentacích, nebo vhodné náhrady, musí být také nainstalována, aby se text správně vykresloval.

## **Často kladené otázky**

### Jak mohu ověřit, že je Aspose.Slides integrován správně?

Sestavte projekt, vytvořte prázdnou [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a uložte ji pod novým názvem. Pokud je soubor vytvořen bez vyhození výjimek, knihovna byla úspěšně integrována.

### Jak mohu omezit spotřebu paměti při zpracování velkých prezentací?

Zvyšte limity paměti JVM jen na potřebnou úroveň a v `finally` bloku zavolejte [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) na každé instanci [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), aby se cache okamžitě uvolnila. Tím se předcházejí chybám nedostatku paměti a celková spotřeba paměti zůstává předvídatelná během dávkových operací.

### Mohu vyloučit nechtěné exportní formáty a zmenšit tak konečnou velikost JAR?

Aktuální verze Aspose.Slides jsou distribuovány jako jedna monolitická knihovna, takže není možné během sestavení zakázat konkrétní exportéry jako PDF nebo SVG.