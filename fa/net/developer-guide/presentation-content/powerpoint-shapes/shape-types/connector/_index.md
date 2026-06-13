---
title: مدیریت اتصال‌گرها در ارائه‌ها در .NET
linktitle: اتصال‌گر
type: docs
weight: 10
url: /fa/net/connector/
keywords:
- اتصال‌گر
- نوع اتصال‌گر
- نقطه اتصال‌گر
- خط اتصال‌گر
- زاویه اتصال‌گر
- اتصال اشکال
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به برنامه‌های .NET امکان دهید خطوط را در اسلایدهای PowerPoint ترسیم، متصل و به‌صورت خودکار مسیر دهند — کنترل کامل بر اتصال‌گرهای مستقیم، زاویه‌دار و منحنی را به دست آورید."
---
## **مقدمه**

یک اتصال‌گر پاورپوینت یک خط خاص است که دو شکل را به هم متصل یا لینک می‌کند و حتی زمانی که آنها در یک اسلاید جابجا یا موقعیتشان تغییر می‌کند، به شکل‌ها چسبیده می‌ماند.

اتصال‌گرها معمولاً به *نقطه‌های اتصال* (نقطه‌های سبز) متصل می‌شوند که به طور پیش‌فرض بر تمام شکل‌ها وجود دارند. نقطه‌های اتصال زمانی ظاهر می‌شوند که نشانگر به آنها نزدیک شود.

*نقاط تنظیم* (نقطه‌های نارنجی) که فقط در برخی اتصال‌گرها وجود دارند، برای تغییر موقعیت و شکل اتصال‌گرها استفاده می‌شوند.

## **انواع اتصال‌گرها**

در پاورپوینت می‌توانید از اتصال‌گرهای مستقیم، زاویه‌دار (elbow) و منحنی استفاده کنید.  
Aspose.Slides این اتصال‌گرها را فراهم می‌کند:

| اتصال‌گر | تصویر | تعداد نقاط تنظیم |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **اتصال اشکال با استفاده از اتصال‌گرها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. دو [AutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) را به اسلاید اضافه کنید با استفاده از متد `AddAutoShape` که توسط شیء `Shapes` در دسترس است.
1. یک اتصال‌گر را با استفاده از متد `AddConnector` که توسط شیء `Shapes` در دسترس است، با تعریف نوع اتصال‌گر اضافه کنید.
1. اشکال را با استفاده از اتصال‌گر متصل کنید.
1. متد `Reroute` را صدا بزنید تا کوتاه‌ترین مسیر اتصال اعمال شود.
1. ارائه را ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک اتصال‌گر (یک اتصال‌گر خمیده) بین دو شکل (یک بیضی و یک مستطیل) اضافه کنید:

```c#
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation input = new Presentation())
{                
    // مجموعه اشکال اسلاید خاصی را دسترسی می‌دهد
    IShapeCollection shapes = input.Slides[0].Shapes;

    // یک شکل خودکار بیضی اضافه می‌کند
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // یک شکل خودکار مستطیل اضافه می‌کند
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // یک شکل اتصال‌گر را به مجموعه اشکال اسلاید اضافه می‌کند
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // اشکال را با استفاده از اتصال‌گر متصل می‌کند
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // متد Reroute را فراخوانی می‌کند که کوتاه‌ترین مسیر خودکار بین اشکال را تنظیم می‌کند
    connector.Reroute();

    // ارائه را ذخیره می‌کند
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`متد Connector.Reroute` مسیر اتصال‌گر را بازتنظیم می‌کند و آن را مجبور می‌سازد تا کوتاه‌ترین مسیر ممکن بین اشکال را بگیرد. برای رسیدن به این هدف، این متد ممکن است نقاط `StartShapeConnectionSiteIndex` و `EndShapeConnectionSiteIndex` را تغییر دهد. 
{{% /alert %}} 

## **مشخص کردن نقطه اتصال**

اگر می‌خواهید یک اتصال‌گر دو شکل را با استفاده از نقاط خاصی در اشکال متصل کند، باید نقاط اتصال مورد نظر خود را به این شکل مشخص کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. دو [AutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) را به اسلاید اضافه کنید با استفاده از متد `AddAutoShape` که توسط شیء `Shapes` در دسترس است.
1. یک اتصال‌گر را با استفاده از متد `AddConnector` که توسط شیء `Shapes` در دسترس است، با تعریف نوع اتصال‌گر اضافه کنید.
1. اشکال را با استفاده از اتصال‌گر متصل کنید.
1. نقاط اتصال مورد نظر خود را روی اشکال تنظیم کنید.
1. ارائه را ذخیره کنید.

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
using (Presentation presentation = new Presentation())
{
    // مجموعه اشکال اسلاید خاصی را دسترسی می‌دهد
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // یک شکل اتصال‌گر را به مجموعه اشکال اسلاید اضافه می‌کند
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // یک شکل خودکار بیضی اضافه می‌کند
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // یک شکل خودکار مستطیل اضافه می‌کند
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // اشکال را با استفاده از اتصال‌گر متصل می‌کند
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // شاخص نقطه اتصال مطلوب را برای شکل بیضی تنظیم می‌کند
    uint wantedIndex = 6;

    // بررسی می‌کند که آیا شاخص مطلوب کمتر از حداکثر شمارش سایت است یا خیر
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // نقطه اتصال مطلوب را برای شکل خودکار بیضی تنظیم می‌کند
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // ارائه را ذخیره می‌کند
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم نقطه اتصال‌گر**

می‌توانید یک اتصال‌گر موجود را از طریق نقاط تنظیم آن تنظیم کنید. تنها اتصال‌گرهایی که نقاط تنظیم دارند می‌توانند به این روش تغییر پیدا کنند. جدول زیر را در بخش **[انواع اتصال‌گرها](/slides/fa/net/connector/#types-of-connectors)** ببینید.

### **مورد ساده**

یک مورد را در نظر بگیرید که در آن یک اتصال‌گر بین دو شکل (A و B) از یک شکل سوم (C) عبور می‌کند:

![مشکل اتصال](connector-obstruction.png)

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

برای اجتناب یا دور زدن شکل سوم، می‌توانیم اتصال‌گر را با جابجایی خط عمودی آن به سمت چپ این‌گونه تنظیم کنیم:

![مشکل اتصال اصلاح شده](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **موارد پیچیده**

برای انجام تنظیمات پیچیده‌تر، باید این موارد را در نظر بگیرید:

* نقطه قابل تنظیم یک اتصال‌گر به‌ شدت به فرمولی که موقعیت آن را محاسبه و تعیین می‌کند مرتبط است. بنابراین تغییر مکان نقطه ممکن است شکل اتصال‌گر را تغییر دهد.
* نقاط تنظیم یک اتصال‌گر در یک آرایه به‌صورت ترتیب سخت‌گیرانه‌ای تعریف می‌شوند. نقاط تنظیم از نقطه شروع اتصال‌گر تا انتهای آن شماره‌گذاری می‌شوند.
* مقادیر نقاط تنظیم درصد عرض/ارتفاع شکل اتصال‌گر را نشان می‌دهند.
  * شکل توسط نقاط شروع و پایان اتصال‌گر ضرب در ۱۰۰۰ محدود می‌شود.
  * نقطه اول، نقطه دوم و نقطه سوم به ترتیب درصد از عرض، درصد از ارتفاع و دوباره درصد از عرض را تعریف می‌کنند.
* برای محاسباتی که مختصات نقاط تنظیم یک اتصال‌گر را تعیین می‌کنند، باید چرخش اتصال‌گر و انعکاس آن را در نظر بگیرید. **نکته** این است که زاویه چرخش تمام اتصال‌گرهای نشان‌داده‌شده در زیر **[انواع اتصال‌گرها](/slides/fa/net/connector/#types-of-connectors)** صفر است.

#### **مورد 1**

یک مورد را در نظر بگیرید که در آن دو شیء قاب متن از طریق یک اتصال‌گر به هم متصل هستند:

![اتصال‌گر شکل پیچیده](connector-shape-complex.png)

```c#
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
// اسلاید اول ارائه را دریافت می‌کند
ISlide sld = pres.Slides[0];
// اشکالی که از طریق یک اتصال‌گر به هم وصل می‌شوند را اضافه می‌کند
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// یک اتصال‌گر اضافه می‌کند
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// جهت اتصال‌گر را مشخص می‌کند
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// رنگ اتصال‌گر را مشخص می‌کند
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// ضخامت خط اتصال‌گر را مشخص می‌کند
connector.LineFormat.Width = 3;

// اشکال را با استفاده از اتصال‌گر به هم متصل می‌کند
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// نقاط تنظیم اتصال‌گر را دریافت می‌کند
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**تنظیم**

می‌توانیم مقادیر نقاط تنظیم اتصال‌گر را با افزایش درصد عرض و ارتفاع متناظر به ترتیب ۲۰٪ و ۲۰۰٪ تغییر دهیم:

```c#
// مقادیر نقاط تنظیم را تغییر می‌دهد
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

![اتصال‌گر تنظیم شده 1](connector-adjusted-1.png)

برای تعریف مدلی که به ما امکان تعیین مختصات و شکل اجزای فردی اتصال‌گر را بدهد، بیایید یک شکل ایجاد کنیم که به مؤلفه افقی اتصال‌گر در نقطه connector.Adjustments[0] مربوط باشد:

```c#
// رسم مؤلفه عمودی اتصال‌گر

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

![اتصال‌گر تنظیم شده 2](connector-adjusted-2.png)

#### **مورد 2**

در **مورد 1**، یک عملیات ساده تنظیم اتصال‌گر را با استفاده از اصول پایه نشان دادیم. در شرایط معمول، باید چرخش اتصال‌گر و نمایش آن (که توسط connector.Rotation، connector.Frame.FlipH و connector.Frame.FlipV تنظیم می‌شوند) را در نظر بگیرید. اکنون فرآیند را نشان می‌دهیم.

ابتدا، یک شیء قاب متن جدید (**To 1**) را به اسلاید اضافه کنیم (برای مقاصد اتصال) و یک اتصال‌گر (سبز) جدید ایجاد کنیم که آن را به اشیائی که قبلاً ساخته‌ایم متصل کند.

```c#
// یک شیء بایندینگ جدید ایجاد می‌کند
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// یک اتصال‌گر جدید ایجاد می‌کند
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// اشیاء را با استفاده از اتصال‌گر تازه ایجاد شده متصل می‌کند
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// نقاط تنظیم اتصال‌گر را دریافت می‌کند
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// مقادیر نقاط تنظیم را تغییر می‌دهد 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

![اتصال‌گر تنظیم شده 3](connector-adjusted-3.png)

دوم، بیایید یک شکل ایجاد کنیم که به مؤلفه افقی اتصال‌گر که از نقطه تنظیم جدید connector.Adjustments[0] عبور می‌کند، مرتبط باشد. مقادیر داده‌های connector برای connector.Rotation، connector.Frame.FlipH و connector.Frame.FlipV را استفاده می‌کنیم و فرمول تبدیل مختصات مشهور برای چرخش حول یک نقطه x0 را اعمال می‌کنیم:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

در مورد ما، زاویه چرخش شیء ۹۰ درجه است و اتصال‌گر به صورت عمودی نمایش داده می‌شود، بنابراین این کد مربوطه است:

```c#
// مختصات اتصال‌گر را ذخیره می‌کند
x = connector.X;
y = connector.Y;
// در صورت ظاهر شدن، مختصات اتصال‌گر را اصلاح می‌کند
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// مقدار نقطه تنظیم را به عنوان مختصات می‌گیرد
x += connector.Width * adjValue_0.RawValue / 100000;
//  مختصات را تبدیل می‌کند چون Sin(90) = 1 و Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// عرض مؤلفه افقی را با استفاده از مقدار نقطه تنظیم دوم تعیین می‌کند
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

![اتصال‌گر تنظیم شده 4](connector-adjusted-4.png)

ما محاسباتی شامل تنظیمات ساده و نقاط تنظیم پیچیده (نقاط تنظیم با زاویه چرخش) را نشان دادیم. با استفاده از این دانش، می‌توانید مدل خود را توسعه دهید (یا کدی بنویسید) تا یک شیء `GraphicsPath` دریافت کنید یا حتی مقادیر نقاط تنظیم اتصال‌گر را بر اساس مختصات خاص اسلاید تنظیم کنید.

## **یافتن زاویه خطوط اتصال‌گر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. دسترسی به شکل خط اتصال‌گر.
1. از عرض و ارتفاع خط، ارتفاع و عرض فریم شکل برای محاسبه زاویه استفاده کنید.

این کد C# عملیاتی را نشان می‌دهد که در آن زاویه یک شکل خط اتصال‌گر را محاسبه کردیم:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **پرسش‌های متداول**

**چگونه می‌توانم تشخیص دهم که یک اتصال‌گر می‌تواند به یک شکل خاص «چسبانده» شود؟**

بررسی کنید که شکل [نقاط اتصال](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/connectionsitecount/) را در دسترس قرار می‌دهد. اگر هیچ‌کدام وجود نداشته باشند یا شمارنده صفر باشد، چسباندن امکان‌پذیر نیست؛ در این صورت از نقاط انتهایی آزاد استفاده کنید و آنها را به‌صورت دستی موقعیت‌دهی کنید. منطقی است قبل از الصاق، شمار نقاط اتصال را بررسی کنید.

**اگر یکی از اشکال متصل‌شده را حذف کنم، چه اتفاقی برای اتصال‌گر می‌افتد؟**

سرهای آن جدا می‌شوند؛ اتصال‌گر به عنوان یک خط عادی با شروع/پایان آزاد بر روی اسلاید باقی می‌ماند. می‌توانید آن را حذف کنید یا ارتباطات را دوباره اختصاص دهید و در صورت نیاز، [بازتنظیم](https://reference.aspose.com/slides/fa/net/aspose.slides/connector/reroute/) کنید.

**آیا اتصال‌گرها هنگام کپی یک اسلاید به ارائه دیگری حفظ می‌شوند؟**

عموماً بله، به‌شرطی که اشکال هدف نیز کپی شوند. اگر اسلاید بدون اشکال متصل‌شده به فایل دیگری اضافه شود، سرها آزاد می‌شوند و باید دوباره متصل شوند.