---
title: Přizpůsobení tvarů prezentace na Android
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
- editační body
- přidat bod
- odebrat bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Android v Javě: geometrické cesty, zakřivené rohy, kompozitní tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) a [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) pro úpravu existujících tvarů, provádění základních operací úprav cest, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

Také demonstruje, jak vytvořit vlastní a kompozitní tvary, sestavit tvary se zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, a kontrolovat prvky tvaru pomocí Androidových pole bodů.

## **Změna tvaru pomocí editačních bodů**

V PowerPointu můžete použít **Edit Points** pro úpravu čtverce:

* Přesunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![prehlad_obrazek](custom_shape_0.png)

Při úpravě tvarů v PowerPointu mějte na paměti tato pravidla:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Cesta tvaru se skládá z kotevních bodů spojených úseky.
* Úsek může být přímý nebo zakřivený. Kotevní body a řídicí úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu se sousední úseky mohou setkat pod úhlem.
  * U hladkého bodu jsou dva řídicí úchyty zarovnány a stejně vzdálené od kotevního bodu.
  * U přímého bodu jsou dva řídicí úchyty zarovnány, ale mohou být v různých vzdálenostech od kotevního bodu.
* Posunutím kotevních bodů nebo úpravou jejich úchytů měníte obrys tvaru.

Pro úpravu tvarů PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) a rozhraní [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) z instance [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) můžete použít metodu [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) .
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) pro tvary s jednou cestou a [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) pro tvary s více cestami.
* Pro přidání úseků můžete použít metody pod [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) .
* Pomocí metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) a [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) jako pole úseků cesty.

## **Jednoduché operace úpravy**

Použijte následující metody pro úpravu geometrické cesty. Přetížení, která přijímají index, vloží úsek na tuto nulově indexovanou pozici v poli úseků cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma řídicími body a koncovým bodem. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním řídicím bodem a koncovým bodem. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Uzavřít aktuální figuru propojením koncového bodu se startovním bodem. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Nastavit počáteční bod figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Odstranit úsek na nulově indexované pozici. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) a aplikuje upravenou cestu pomocí [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Souřadnice jsou lokální k tvaru: oba nové body jsou ve středu, 100 bodů od levého okraje a 50 bodů od horního okraje. Indexy úseků 1 a 4 je umístí na horní a spodní hranu, čímž tyto hrany stáhnou dovnitř.

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

![priklad1_obrazek](custom_shape_1.png)

## **Odstranění bodů z tvaru**

Tento příklad změní obrys tvaru srdce odebráním úseku na nulově indexované pozici 2 pomocí [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Aplikací upravené cesty pomocí [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) se aktualizuje kontura tvaru.

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
![priklad2_obrazek](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pěticípou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a zanoření; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) a aplikována na obdélníkový tvar pomocí [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), čímž nahradí jeho obrys.

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
![priklad3_obrazek](custom_shape_3.png)

## **Vytvoření kompozitního vlastního tvaru**

Tento příklad definuje dva uzavřené [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) objekty pro horní a spodní třetinu tvaru. Aplikací obou cest pomocí [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) vznikne jeden kompozitní tvar s mezerou napříč jeho prostřední třetinou.

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
![priklad4_obrazek](custom_shape_4.png)

## **Vytvoření vlastního tvaru s zakřivenými rohy**

Tento příklad kombinuje přímé úseky s [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) pro vytvoření tvaru se zakřivenými rohy dovnitř. Každá velikost rohu určuje šířku a výšku oblouku v bodech a úhel -90° vykresluje proti směru hodinových ručiček čtvrtkruh. Hotová cesta je aplikována pomocí [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), a prezentace je uložena ve formátu PPTX.

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

Následující pomocná metoda kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím úsekem. Načte [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) a porovná poslední úsekův [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) s [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Vrací false, pokud neexistují neprázdné cesty. Tento test kontroluje poslední příkaz každé cesty; neprozkoumává všechny podfigury uvnitř cesty. Příklad vypíše `true` pro obdélník.

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

## **Inspekce příkazů cesty geometrie**

Stáhněte [contour.pptx](contour.pptx) a nahraďte ukázkové jméno souboru jeho cestou na zařízení. První tvar na první snímku má rovnou horní hranu, kubickou Bézierovu křivku a rovný uzavírací úsek. Použijte [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) k načtení cest tvaru a [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) k načtení úseků každé cesty ve výkresovém pořadí. Pro každý úsek metoda [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) identifikuje příkaz a určuje, jak interpretovat hodnoty vrácené metodou [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

Tvar se nachází v bodě (200, 100) na snímku. Uvedené souřadnice jsou lokální k tvaru, s (0, 0) v levém horním rohu, x roste doprava a y roste dolů. Uzavírací úsek se vrací na počáteční bod bez dalších souřadnic.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint tvar s rovnou horní hranou, zakřiveným okrajem z pravého horního do levého dolního a rovnou levou hranou](contour.png)

## **Extrahování a inspekce prvků tvaru**

Použijte [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) k prozkoumání existujícího tvaru jako prvků obsahujících body cesty a typy bodů. Přetypujte každý vrácený [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) a získejte pole bodů a typů pomocí metod [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) a [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Tato reprezentace je užitečná pro analýzu kontury nebo předávání geometrie vlastním kreslicím nástrojům.

Příklad otevře input.pptx, najde první geometrický tvar přímo na první snímku a vytiskne jeho úseky cesty. Použijte prezentaci obsahující tvar s přímými i zakřivenými úseky, abyste viděli oba typy výstupu. Neprohledává skupiny.

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
                int pointType = types[i] & 0x07; // Zachovat typ úseku, vynechávající příznaky.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Spotřebovat oba řídicí body a koncový bod.
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

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` začíná figuru a typ `1` kreslí čáru od předchozího bodu k aktuálnímu bodu. Kubický Bézierův úsek začíná předchozím koncovým bodem a používá tři po sobě jdoucí záznamy typu `3`: dva řídicí body a nový koncový bod. Smyčka tyto tři položky spotřebuje najednou a testuje koncový bod na uzavření.

Typy bodů také obsahují příznaky. Maskujte pomocí `0x07` pro určení typu úseku a testujte `0x80` zvlášť pro detekci uzavřené podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená Bézierův koncový bod, který uzavírá. Java ukládá tyto příznaky v podepsaných bytech; maskování zachovává zamýšlené bitové hodnoty. Porovnání surové hodnoty pouze s `1` nebo `3` by tyto případy neodhalilo. Další příznaky, jako pomlčka (`0x10`) a značka (`0x20`), nemění základní typ úseku.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 palce), s X rostoucím doprava a Y rostoucím dolů. Pro negrupovaný tvar extrahované souřadnice již zahrnují pozici vrácenou metodou [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) a [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) a odrážejí aktuální šířku a výšku. Například neotočený obdélník na `(100, 200)` se rozměry `120 × 80` má hranice kontury `(100, 200)`–`(220, 280)`. Nepřidávejte pozici tvaru znovu. Odečtěte jeho X a Y pro získání souřadnic relativních k jeho neotočenému rámečku.

Extrahované body neaplikují rotaci tvaru, kterou vrací [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), ani horizontální a vertikální převrácení. Pro reprodukci zobrazené kontury aplikujte tyto transformace kolem středu tvaru. U skupinových tvarů také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou konečné souřadnice na snímku, a neopakujte posun nebo měřítko, pokud již bylo zahrnuto v rámci dítěte.

**Inspekce vs. úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, když vaše analytické nebo kreslicí kódy potřebují pole bodů/typů. Použijte [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) když potřebujete geometrické příkazy v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Aplikujte upravené cesty pomocí [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) nebo [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstane u tvaru; změní se pouze kontura. Výplň a obrys se automaticky aplikují na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu tvaru [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-); geometrie se otočí spolu s tvarem, protože je vázána na jeho vlastní souřadnicový systém.

**Mohu převést vlastní tvar na obrázek, aby byl „uzamčen“ výsledek?**

Ano. Exportujte požadovanou [snímek](/slides/cs/androidjava/convert-powerpoint-to-png/) nebo samotný [tvar](/slides/cs/androidjava/create-shape-thumbnails/) do rastrového formátu; to zjednoduší další práci s komplexními geometriemi.