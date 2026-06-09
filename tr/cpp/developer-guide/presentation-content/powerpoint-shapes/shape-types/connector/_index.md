---
title: C++ Kullanarak Sunumlarda Bağlayıcıları Yönetme
linktitle: Bağlayıcı
type: docs
weight: 10
url: /tr/cpp/connector/
keywords:
- bağlayıcı
- bağlayıcı tipi
- bağlayıcı noktası
- bağlayıcı çizgisi
- bağlayıcı açısı
- şekilleri bağla
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "C++ uygulamalarını PowerPoint slaytlarında çizim yapmaya, bağlamaya ve çizgileri otomatik yönlendirmeye güçlendirin—düz, dirsek ve eğimli bağlayıcılar üzerinde tam kontrol elde edin."
---
## **Giriş**

PowerPoint bağlayıcısı, iki şekli birbirine bağlayan özel bir çizgidir ve bir slaytta taşınsalar veya yeniden konumlandırılsalar bile şekillere tutunur. 

Bağlayıcılar genellikle *bağlantı noktalarına* (yeşil noktalar) bağlanır; bu noktalar tüm şekillerde varsayılan olarak bulunur. Bağlantı noktaları, imleç yaklaştığında görünür.

*Sıfır noktalar* (turuncu noktalar), yalnızca belirli bağlayıcılarda bulunur ve bağlayıcıların konum ve şekillerini değiştirmek için kullanılır.

## **Bağlayıcı Türleri**

PowerPoint'te düz, dirsek (köşeli) ve eğimli bağlayıcıları kullanabilirsiniz. 

Aspose.Slides bu bağlayıcıları sağlar:

| Bağlayıcı | Image | Ayarlama noktalarının sayısı |
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

## **Şekilleri Bağlayıcılarla Bağlamak**

1. Bir [Sunum](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfı örneği oluşturun.  
1. Slaytın indeksine göre bir referans alın.  
1. `Shapes` nesnesinin `AddAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.auto_shape) ekleyin.  
1. Bağlayıcı tipini belirterek `Shapes` nesnesinin `AddConnector` yöntemiyle bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla bağlayın.  
1. En kısa bağlantı yolunu uygulamak için `Reroute` metodunu çağırın.  
1. Sunumu kaydedin.  

Bu C++ kodu iki şekil (bir elips ve bir dikdörtgen) arasında bir dirsek bağlayıcı eklemenizi gösterir:

```c++
// Belgeler dizininin yolu.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// İstenen sunumu yükler.
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// İlk slayta erişir.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Belirli bir slayt için şekil koleksiyonuna erişir.
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Bir Elips otomatik şekli ekler.
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Bir Dikdörtgen otomatik şekli ekler.
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Slayt şekil koleksiyonuna bir bağlayıcı şekli ekler.
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Şekilleri bağlayıcıyı kullanarak bağlar.
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Şekiller arasındaki otomatik en kısa yolu ayarlayan reroute metodunu çağırır.
	connector->Reroute();
	
	// Sunumu kaydeder.
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

`connector->Reroute` yöntemi bir bağlayıcıyı yeniden yönlendirir ve şekiller arasında mümkün olan en kısa yolu almasını zorlar. Bu amaçla, yöntem `StartShapeConnectionSiteIndex` ve `EndShapeConnectionSiteIndex` noktalarını değiştirebilir. 

{{% /alert %}} 

## **Bağlantı Noktasını Belirtmek**

Bağlayıcının iki şekli belirli noktalarla bağlamasını istiyorsanız, tercih ettiğiniz bağlantı noktalarını şu şekilde belirtmelisiniz:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfı örneği oluşturun.  
1. Slaytın indeksine göre bir referans alın.  
1. `Shapes` nesnesinin `AddAutoShape` yöntemiyle slayta iki [AutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.auto_shape) ekleyin.  
1. Bağlayıcı tipini belirterek `Shapes` nesnesinin `AddConnector` yöntemiyle bir bağlayıcı ekleyin.  
1. Şekilleri bağlayıcıyla bağlayın.  
1. Şekillerde tercih ettiğiniz bağlantı noktalarını ayarlayın.  
1. Sunumu kaydedin.  

Bu C++ kodu tercih edilen bir bağlantı noktasının nasıl belirtileceğini gösterir:

```c++
	// Belgeler dizininin yolu.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// İstenen sunumu yükler
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// İlk slayta erişir
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Belirli bir slayt için şekil koleksiyonuna erişir
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Bir Elips otomatik şekli ekler
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Bir Dikdörtgen otomatik şekli ekler
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Slaytın şekil koleksiyonuna bir bağlayıcı şekli ekler
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Şekilleri bağlayıcıyı kullanarak bağlar
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Elips şekli üzerinde tercih edilen bağlantı nokta indeksini ayarlar
	int wantedIndex = 6;

	// Tercih edilen indeksin maksimum site indeks sayısından küçük olup olmadığını kontrol eder
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Elips otomatik şekli üzerinde tercih edilen bağlantı noktasını ayarlar
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Sunumu kaydeder
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bağlayıcı Noktasını Ayarlamak**

Varolan bir bağlayıcıyı ayar noktalarıyla düzenleyebilirsiniz. Yalnızca ayar noktalarına sahip bağlayıcılar bu şekilde değiştirilebilir. **[Bağlayıcı Türleri](/slides/tr/cpp/connector/#types-of-connectors)** altındaki tabloya bakın. 

### **Basit Durum**

İki şekil (A ve B) arasında bir bağlayıcı üçüncü bir şekil (C) üzerinden geçiyorsa:

![connector-obstruction](connector-obstruction.png)

Kod:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Üçüncü şekli atlatmak için bağlayıcıyı şu şekilde sola doğru bir dik çizgiyle ayarlayabiliriz:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Karmaşık Durumlar** 

Daha karmaşık ayarlamalar yapmak için aşağıdaki unsurları göz önünde bulundurmalısınız:

* Bir bağlayıcının ayarlanabilir noktası, konumunu hesaplayan bir formülle güçlü bir şekilde ilişkilidir. Bu nedenle noktanın konumundaki değişiklik bağlayıcının şeklini etkileyebilir.  
* Bağlayıcının ayar noktaları bir dizi içinde kesin bir sırayla tanımlanır. Ayar noktaları bağlayıcının başlangıç noktasından sonuna doğru numaralandırılır.  
* Ayar noktası değerleri, bağlayıcı şeklinin genişlik/yükseklik yüzdesini yansıtır.  
  * Şekil, bağlayıcının başlangıç ve bitiş noktaları ile 1000 ile çarpılarak sınırlanır.  
  * İlk nokta, ikinci nokta ve üçüncü nokta sırasıyla genişlik, yükseklik ve tekrar genişlik yüzdesini tanımlar.  
* Bağlayıcının ayar noktalarının koordinatlarını belirleyen hesaplamalarda bağlayıcının dönme ve yansıtma durumları dikkate alınmalıdır. **Not**: **[Bağlayıcı Türleri](/slides/tr/cpp/connector/#types-of-connectors)** altında gösterilen tüm bağlayıcıların dönme açısı 0’dır.

#### **Durum 1**

İki metin çerçevesi nesnesinin bir bağlayıcıyla birbirine bağlandığı bir senaryo düşünelim:

![connector-shape-complex](connector-shape-complex.png)

Kod:

```c++
// PPTX dosyasını temsil eden bir sunum sınıfı örnekler
auto pres = System::MakeObject<Presentation>();
// Sunumdaki ilk slaytı alır
auto slide = pres->get_Slides()->idx_get(0);
// İlk slayttaki şekilleri al
auto shapes = slide->get_Shapes();
// Bağlayıcı aracılığıyla birleştirilecek şekilleri ekler
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Bir bağlayıcı ekler
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Bağlayıcının yönünü belirtir
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Bağlayıcının çizgi kalınlığını belirtir
lineFormat->set_Width(3);
// Bağlayıcının rengini belirtir
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Şekilleri bağlayıcı ile birbirine bağlar
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Bağlayıcı için ayar noktalarını alır
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Ayarlama**

Bağlayıcının ayar noktası değerlerini, ilgili genişlik ve yükseklik yüzdelerini sırasıyla %20 ve %200 artırarak değiştirebiliriz:

```c++
// Ayar noktalarının değerlerini değiştirir
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Sonuç:

![connector-adjusted-1](connector-adjusted-1.png)

Bağlayıcının bireysel parçalarının koordinatlarını ve şeklini belirleyen bir model oluşturmak için, bağlayıcı.Adjustments[0] noktasındaki yatay bileşene karşılık gelen bir şekil oluşturalım:

```c++
// Bağlayıcının dikey bileşenini çizer
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Sonuç:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Durum 2**

**Durum 1**’de temel prensiplerle basit bir bağlayıcı ayarlama işlemi gösterdik. Normal durumlarda, bağlayıcının `Rotation`, `Frame.FlipH` ve `Frame.FlipV` özellikleriyle belirlenen dönme ve görüntüleme yönlerini de hesaba katmanız gerekir. Şimdi süreci gösterelim.

İlk olarak, slayta bir bağlantı amacıyla yeni bir metin çerçevesi nesnesi (**To 1**) ekleyelim ve bunu mevcut nesnelere bağlayan yeni (yeşil) bir bağlayıcı oluşturalım.

```c++
// Yeni bir bağlama nesnesi oluşturur
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Yeni bir bağlayıcı oluşturur
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Yeni oluşturulan bağlayıcıyı kullanarak nesneleri bağlar
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Bağlayıcı ayar noktalarını alır
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Ayar noktalarının değerlerini değiştirir
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Sonuç:

![connector-adjusted-3](connector-adjusted-3.png)

İkinci olarak, yeni bağlayıcının ayar noktası `connector.Adjustments[0]` üzerinden geçen yatay bileşene karşılık gelen bir şekil oluşturalım. Bağlayıcı verilerindeki `Rotation`, `Frame.FlipH` ve `Frame.FlipV` değerlerini kullanarak, verilen bir x0 noktasına göre dönüş için yaygın koordinat dönüşüm formülünü uygulayacağız:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Bizim durumumuzda nesnenin dönüş açısı 90 derecedir ve bağlayıcı dikey olarak görüntülenir, bu yüzden ilgili kod şu şekildedir:

```c++

```

Sonuç:

![connector-adjusted-4](connector-adjusted-4.png)

Basit ayarlamaları ve dönme açılarına sahip karmaşık ayar noktalarını içeren hesaplamaları gösterdik. Edindiğiniz bilgiyle, belirli slayt koordinatlarına dayalı bir `GraphicsPath` nesnesi elde etmek veya bir bağlayıcının ayar noktası değerlerini ayarlamak için kendi modelinizi (veya kodunuzu) geliştirebilirsiniz.

## **Bağlayıcı Çizgilerinin Açısını Bulmak**

1. Bir [Sunum](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfı örneği oluşturun.  
1. Slaytın indeksine göre bir referans alın.  
1. Bağlayıcı çizgi şekline erişin.  
1. Açıyı hesablamak için çizgi genişliğini, yüksekliğini, şekil çerçevesi yüksekliğini ve şekil çerçevesi genişliğini kullanın.  

Bu C++ kodu bir bağlayıcı çizgi şeklinin açısını nasıl hesaplayacağınızı gösterir:

```c++
void ConnectorLineAngle()
{

	// Belgeler dizininin yolu.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// İstenen sunumu yükler
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// İlk slayta erişir
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Slaytların şekil koleksiyonuna erişir
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **SSS**

**Bir bağlayıcının belirli bir şekle “yapıştırılıp” yapıştırılamadığını nasıl anlayabilirim?**

Şeklin [bağlantı noktalarını](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/get_connectionsitecount/) expose ettiğini kontrol edin. Hiçbiri yoksa veya sayısı sıfırsa, yapıştırma mümkün değildir; bu durumda serbest uçları kullanıp manuel konumlandırmalısınız. Bağlantı nokta sayısını eklemeden önce kontrol etmek mantıklıdır.

**Bağlı şekillerden birini sildiğimde bağlayıcı ne olur?**

Uçları ayrılır; bağlayıcı serbest başlangıç/bitiş noktalarına sahip normal bir çizgi olarak slaytta kalır. İsterseniz silebilir ya da bağlantıları yeniden atayabilir ve gerekirse [reroute](https://reference.aspose.com/slides/tr/cpp/aspose.slides/connector/reroute/) yapabilirsiniz.

**Bir slaytı başka bir sunuma kopyaladığımda bağlayıcı bağlamaları korunur mu?**

Genellikle evet, hedef şekiller de kopyalandığında korunur. Slayt, bağlı şekiller olmadan başka bir dosyaya eklenirse uçlar serbest olur ve yeniden eklemeniz gerekir.