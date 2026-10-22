---
title: Přizpůsobení tvarů prezentace na Androidu
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/androidjava/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- upravit body
- přidat bod
- odebrat bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v PowerPoint prezentacích pomocí Aspose.Slides pro Android v jazyce Java: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentací v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) a [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) k úpravě existujících tvarů, provádění základních operací úpravy cesty, přidávání nebo odebírání bodů a aplikaci aktualizované geometrie zpět na tvar.

Také ukazuje, jak vytvořit vlastní a složené tvary, vytvořit tvary s zakřivenými rohy, určit, zda je geometrie tvaru uzavřená, a prozkoumat elementy tvaru pomocí Android pole bodů.

## **Změna tvaru pomocí editačních bodů**

V PowerPointu můžete použít **Edit Points** k úpravě čtverce:

* Posunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Při úpravě tvarů v PowerPointu mějte na paměti následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Cesta tvaru se skládá z kotevních bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Kotevní body a ovládací úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu se sousední segmenty mohou setkat pod úhlem.
  * U hladkého bodu jsou dva ovládací úchyty zarovnané a ve stejné vzdálenosti od kotevního bodu.
  * U přímého bodu jsou dva ovládací úchyty zarovnané, ale mohou být od kotevního bodu ve různých vzdálenostech.
* Posun kotevních bodů nebo úprava jejich úchytných úchytů mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) a rozhraní [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) z instance [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) můžete použít metodu [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) pro tvary s jednou cestou a [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody pod [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Pomocí metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) a [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) jako pole segmentů cesty.

## **Jednoduché operace úprav**

Použijte následující metody pro úpravu geometrické cesty. Přetížení, která přijímají index, vloží segment na danou nulovou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma řídícími body a koncovým bodem. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním řídícím bodem a koncovým bodem. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Uzavřít aktuální útvar spojením jeho koncového bodu s počátečním bodem. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Nastavit počáteční bod útvaru. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Odstranit segment na nulovém indexu. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) a použije upravenou cestu metodou [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Souřadnice jsou lokální k tvaru: oba nové body jsou ve středu, 100 bodů od levého okraje a 50 bodů od horního. Indexy segmentů 1 a 4 je umístí na horní a dolní hranu, čímž tyto hrany stáhnou dovnitř.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Odstranění bodů ze tvaru**

Tento příklad mění obrys ve tvaru srdce odstraněním segmentu na nulovém indexu 2 pomocí [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Použití upravené cesty metodou [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aktualizuje konturu tvaru.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pěticípou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a zapuštění; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) a aplikována na obdélníkový tvar pomocí [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), čímž nahradí jeho obrys.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Vytvoření složeného vlastního tvaru**

Tento příklad definuje dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) pro horní a dolní třetinu tvaru. Použití obou cest pomocí [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) vytvoří jeden složený tvar s mezerou napříč jeho střední třetinou.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Vytvoření vlastního tvaru se zakřivenými rohy**

Tento příklad kombinuje přímé segmenty s [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) k vytvoření tvaru se zakřivenými rohy dovnitř. Každá velikost rohu určuje šířku a výšku oblouku v bodech a úhel -90 stupňů vykreslí proti směru hodinových ručiček čtvrtkružnici. Dokončená cesta je použita pomocí [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) a prezentace je uložena ve formátu PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zjištění, zda je geometrie tvaru uzavřená**

Následující pomocná metoda kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím segmentem. Načte [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) a porovná příkaz posledního segmentu [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) s [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Vrátí false, pokud neexistují neprázdné cesty. Toto kontroluje poslední příkaz každé cesty; neprozkoumává každou subfiguru uvnitř cesty. Příklad vypíše `true` pro obdélník.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Extrahování a inspekce elementů tvaru**

Použijte [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) k prozkoumání existujícího tvaru jako elementů obsahujících body cesty a typy bodů. Přetypujte každý vrácený [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) a získejte pole bodů a typů pomocí metod [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) a [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Toto znázornění je užitečné pro analýzu kontury nebo předání geometrie vlastním kreslícím nástrojům.

Příklad otevře soubor input.pptx, najde první geometrický tvar přímo na první snímku a vypíše jeho segmenty cesty. Použijte prezentaci obsahující tvar s přímými i zakřivenými segmenty, abyste viděli oba typy výstupu. Neprohledává skupiny.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Zachovat typ segmentu, vyjma příznaků.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Spotřebovat oba řídící body a koncový bod.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` zahajuje útvar a typ `1` kreslí čáru od předchozího bodu k aktuálnímu. Kubický Bézierův segment začíná na předchozím koncovém bodě a používá tři po sobě jdoucí položky typu `3`: dva řídící body následované novým koncovým bodem. Smyčka spotřebuje tyto tři položky najednou a kontroluje koncový bod pro uzavření.

Typy bodů také obsahují příznaky. Maskujte pomocí `0x07` k určení typu segmentu a testujte `0x80` samostatně k detekci uzavřeného podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který uzavírá podcestu. Java ukládá tyto příznaky do podepsaných bytů; maskování zachovává zamýšlené bitové hodnoty. Porovnání surové hodnoty jen s `1` nebo `3` by tyto případy prošvihlo. Další příznaky, jako čárka (`0x10`) a značka (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.**  
Bodů se měří v bodech (1/72 palce), přičemž X roste doprava a Y dolů. Pro netvořený (ne‑skupinový) tvar již extrahované souřadnice zahrnují pozici vrácenou metodami [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) a [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) a odrážejí jeho aktuální šířku a výšku. Například neotočený obdélník na `(100, 200)` s velikostí `120 × 80` má obrysové meze `(100, 200)`–`(220, 280)`. Nepřidávejte pozici tvaru znovu. Odečtěte jeho X a Y, abyste získali souřadnice relativní k jeho neotočenému rámu.

Extrahované body neaplikují rotaci tvaru, vrácenou metodou [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), ani horizontální a vertikální převrácení. Pro reprodukci zobrazeného obrysu aplikujte tyto transformace kolem středu tvaru. Pro seskupené tvary také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou finální vykreslené souřadnice snímku, ani neaplikujte translační nebo škálovací transformaci dvakrát, pokud už jsou ve rámu dítěte zahrnuty.

Inspekce versus úprava. Extrahovaná pole popisují obrys; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, když vaše analytické nebo kreslicí kódy potřebují pole bodů/typů. Použijte [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) pokud potřebujete geometrické příkazy v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Aplikujte upravené cesty pomocí [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) nebo [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**  
Styl zůstává u tvaru; mění se pouze obrys. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**  
Použijte metodu [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) tvaru; geometrie se otáčí spolu s tvarem, protože je vázána na jeho vlastní souřadnicový systém.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**  
Ano. Exportujte požadovanou oblast [slide](/slides/cs/androidjava/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/androidjava/create-shape-thumbnails/) do rastrového formátu; toto usnadní další práci s komplexními geometriemi.