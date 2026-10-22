---
title: JavaScript ile Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/nodejs-java/custom-shape/
keywords:
- özel şekil
- şekil ekle
- şekil oluştur
- şekil değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- düzenleme noktaları
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- kavisli köşe
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak PowerPoint sunumlarında şekil oluşturun ve özelleştirin: geometri yolları, kavisli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştirileceğini açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemleri yapmak, nokta eklemek veya kaldırmak ve güncellenmiş geometrinin bir şekle geri uygulanmasını göstermek için [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir. Ayrıca özel ve birleşik şekiller oluşturmayı, kavisli köşeli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi, şekil öğelerini incelemeyi ve Java AWT metin konturlarını geometri yollarına dönüştürmeyi gösterir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

PowerPoint'te **Edit Points** özelliğini kullanarak bir kareyi değiştirebilirsiniz:

* Bir köşeyi içe veya dışa doğru hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Nokta düzenleme, bir şeklin dış hattını değiştirmenizi veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmanızı sağlar.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda bulundurun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan bağlantı (anchor) noktalarından oluşur.
* Bir segment düz veya kavisli olabilir. Bağlantı noktaları ve kontrol tutamaçları şeklinin şeklini belirler.
* Bağlantı noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Yumuşak noktada, iki kontrol tutamağı hizalıdır ve bağlantı noktasına eşit mesafededir.
  * Düz noktada, iki kontrol tutamağı hizalıdır ancak bağlantı noktasına farklı mesafelerde olabilir.
* Bağlantı noktalarını hareket ettirmek veya tutamaçlarını ayarlamak şeklin dış hattını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) sınıfını sunar.

* Bir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) nesnesinin bir geometri yolunu temsil eder.
* [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) almak için [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) yöntemini kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ayarlamak üzere şu yöntemleri kullanabilirsiniz: tek bir yola sahip şekiller için [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), birden fazla yola sahip şekiller için [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) ve [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) yöntemini kullanarak bir [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) geometrisinin yol verilerini yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) nesnesini [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) aracılığıyla okuyabilir ve segmentleri bir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) üzerine yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir indeks kabul eden aşırı yüklemeler, segmenti yolun sıfır tabanlı indeksindeki konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekle veya ekle. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| İki kontrol noktası ve bir uç nokta ile bir kübik Bézier eğrisi ekleyin veya yerleştirin. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Bir kontrol noktası ve bir uç nokta ile bir ikinci dereceden Bézier eğrisi ekleyin veya yerleştirin. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Belirtilen boyut ve derece cinsinden açılarıyla bir eliptik yay ekleyin. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Uç noktasını başlangıç noktasına bağlayarak mevcut şekli kapatın. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Bir şeklin başlangıç noktasını ayarlayın. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Sıfır tabanlı bir indeksteki segmenti kaldırın. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) kullanarak dikdörtgen bir şekle iki nokta ekler ve düzenlenmiş yolu [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ile uygular. Koordinatlar şekle göre lokaldir: iki yeni nokta da merkezde, soldan 100 puan, üstten 50 puan uzaklıktadır. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirerek bu kenarları içe doğru çeker.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Bir Şekilden Noktaları Kaldırma**

Bu örnek, [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) kullanarak sıfır tabanlı 2. indeksteki segmenti kaldırarak kalp şeklindeki dış hatı değiştirir. Değiştirilmiş yolu [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulamak, şeklin konturunu günceller.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olması uçları ve girintileri tanımlar; 72 derece adım, beş uç arasında eşit aralık oluşturur. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) ile kapatılır ve bir dikdörtgen şekle [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanarak dış hatı değiştirir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Bileşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte birlik bölümleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulamak, ortasında bir boşluk bulunan tek bir bileşik şekil oluşturur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Kavisli Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) ile birleştirerek içe doğru kıvrılan köşelere sahip bir şekil oluşturur. Her köşe boyutu, yayı noktalar cinsinden genişlik ve yükseklik olarak ayarlar ve -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır ve sunum PPTX formatında kaydedilir.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapama segmentiyle bitip bitmediğini kontrol eder. [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) okur ve son segmentin [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) sonucunu [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) ile karşılaştırır. Boş yol olmadığında false döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek, bir dikdörtgen için `true` yazdırır.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Şekil Öğelerini Çıkarma ve İnceleme**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) kullanarak mevcut bir şekli yol noktaları ve nokta tiplerini içeren öğeler olarak inceleyin. Dönen her [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) için [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints), [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) yöntemleri aracılığıyla nokta ve tip dizilerini alın. Bu temsili, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için kullanışlıdır.

Örnek, input.pptx dosyasını açar, ilk slayttaki ilk geometri şeklinin doğrudan bulunur ve yol segmentlerini yazdırır. Hem düz hem de kıvrımlı segmentlere sahip bir şekil içeren bir sunum kullanarak her iki tür çıktıyı da görebilirsiniz. Gruplar içinde arama yapmaz.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Segment tipini, bayrakları hariç tutarak koru.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Hem kontrol noktalarını hem de uç noktayı tüket.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Diziler indeks bazında eşleşir: `points[i]` bir noktadır ve `types[i]` onun rolünü tanımlar. Tip `0` bir şekli başlatır, tip `1` önceki noktadan mevcut noktaya bir çizgi çizer. Bir kübik Bézier segmenti önceki uç noktada başlar ve ardışık üç tip-`3` girdisini kullanır: iki kontrol noktası ve ardından yeni uç nokta. Döngü bu üç girdiyi birlikte tüketir ve uç noktanın kapanıp kapanmadığını kontrol eder.

Nokta tipleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi uygulanır ve kapalı bir alt yol tespit etmek için `0x80` ayrı ayrı test edilir. Örneğin, `129` (`0x81`) bir satır uç noktasının bir alt yolu kapattığını, `131` (`0x83`) ise bir Bézier uç noktasının bir alt yolu kapattığını gösterir. Java bu bayrakları işaretli baytlar olarak saklar; maskeleme istenen bit değerlerini korur. Ham değeri yalnızca `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Tire (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar, inç başına 72 nokta (1/72 inç) biriminde ölçülür; X sağa, Y aşağıya doğru artar. Gruplandırılmamış bir şekil için, çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) ve [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliğini yansıtır. Örneğin, `(100, 200)` konumunda, `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` olur. Şeklin konumunu tekrar eklemeyin. X ve Y'sini çıkararak koordinatları döndürülmemiş çerçeveye göre elde edin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) tarafından döndürülen şekil dönüşümünü veya yatay ve dikey çevirileri uygulamaz. Gösterilen konturu yeniden oluşturmak için bu dönüşümleri şeklin merkezi etrafında uygulayın. Gruplandırılmış şekiller için, grup koordinat haritalamasını ve dönüşümleri de hesaba katın; çıkarılan noktaların son render edilen slayt koordinatları olduğunu varsaymayın ve çocuğun çerçevesinde zaten yansıtılmışsa bir çevirme veya ölçeklendirmeyi iki kez uygulamayın.

**İnceleme ve düzenleme karşılaştırması.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz ya da çizim kodunuz nokta/tip dizilerine ihtiyaç duyduğunda bu yöntemi seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyaç duyduğunuzda veya geometrisini düzenlemek istediğinizde [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) yöntemini kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) veya [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) aracılığıyla uygulayın.

## **Java AWT Şekli'ni GeometryPath'e Dönüştürme**

Bu örnek, bir dikdörtgen dış hattı ile geometriye dönüştürülmüş metni birleştirir. Dış hattın [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) yöntemi doldurmayı devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin dış hattını oluşturur. Onun [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceden, kübik ve kapama segmentlerini sağlar; örnek bu segmentleri bir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) üzerine yeniden oynatır.

Java köprüsü, ilgili Java parametreleri için açık float ve byte değerleri kullanır. İteratör, koordinatları bir Java float dizisine yazar; yansıma (reflection) güncellenen değerleri JavaScript'e geri okur. Metin 40 puanlık Arial tipini kullanır. Dış hat, yatayda 20 puan kaydırılır ve görsel üst kısmı şeklin üst kenarının 10 puan altında konumlandırılır. Metin yolu doldurulurken, orijinal dikdörtgen sadece dış hat kalır. Her iki yolu da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulamak, dikdörtgen ve metni içeren tek bir şekil üretir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Taşı.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Çizgi.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // İkinci dereceden Bezier eğrisi.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Kübik Bezier eğrisi.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Şekli kapat.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometri değiştirildikten sonra dolgu ve dış hat ne olur?**  
Stil şekil ile kalır; sadece kontur değişir. Dolgu ve dış hat otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli ve geometrisini doğru şekilde nasıl döndürürüm?**  
[setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) yöntemini kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekil ile birlikte döner.

**Sonucu kilitlemek için özel bir şekli bir görüntüye dönüştürebilir miyim?**  
Evet. Gerekli [slide](/slides/tr/nodejs-java/convert-powerpoint-to-png/) alanını veya [shape](/slides/tr/nodejs-java/create-shape-thumbnails/) öğesini raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.