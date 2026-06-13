---
title: ส่งออกการนำเสนอเป็น HTML พร้อมภาพที่เชื่อมโยงภายนอก
type: docs
weight: 50
url: /th/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกการนำเสนอ
- ส่งออกสไลด์
- ส่งออก PPT
- ส่งออก PPTX
- ส่งออก ODP
- PowerPoint เป็น HTML
- OpenDocument เป็น HTML
- การนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPTเป็น HTML
- PPTXเป็น HTML
- ODPเป็น HTML
- ภาพที่เชื่อมโยง
- ภาพที่เชื่อมโยงภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- C++
- Aspose.Slides
description: "ส่งออกการนำเสนอ PowerPoint และ OpenDocument เป็น HTML ด้วย C++ โดยใช้ Aspose.Slides พร้อมภาพและทรัพยากรอื่น ๆ ที่บันทึกเป็นไฟล์ที่เชื่อมโยงภายนอก"
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกการนำเสนอเป็นไฟล์ HTML ที่เป็นอิสระในตัวเอง รูปภาพและทรัพยากรอื่น ๆ จะถูกเขียนโดยตรงลงใน HTML โดยปกติเป็นข้อมูล Base64 ซึ่งสะดวกเมื่อคุณต้องการไฟล์พกพาเดียว แต่ไม่จำเป็นต้องเป็นรูปแบบที่ดีที่สุดสำหรับเว็บไซต์, CMS หรือสายการแปลงฝั่งเซิร์ฟเวอร์

ใช้ทรัพยากรที่เชื่อมโยงภายนอกเมื่อคุณต้องการ:

- ลดขนาดของเอกสาร HTML;
- แคชรูปภาพ, ฟอนต์, เสียง หรือวิดีโอแยกต่างหากในเบราว์เซอร์หรือ CDN;
- ตรวจสอบ, แทนที่, บีบอัด หรือทำการประมวลผลต่อของทรัพยากรที่สร้างหลังการส่งออก;
- ทำให้โครงสร้างผลลัพธ์ใกล้เคียงกับสิ่งที่เว็บแอปพลิเคชันคาดหวัง

สำหรับกระบวนการแปลง HTML อย่างทั่วไป ให้ดูที่ [แปลง PowerPoint เป็น HTML](/slides/th/cpp/convert-powerpoint-to-html/). บทความนี้มุ่งเน้นที่ส่วนการเชื่อมโยงทรัพยากรของการส่งออก

## **วิธีการทำงานของการส่งออกทรัพยากรที่เชื่อมโยง**

[ILinkEmbedController](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/) ให้แอปพลิเคชันของคุณตัดสินใจ, ทรัพยากรต่อทรัพยากร, ว่าตัวส่งออกจะแทรกข้อมูลลงใน HTML หรือบันทึกเป็นไฟล์ภายนอกและเขียนลิงก์

อินเทอร์เฟซมีสามเมธอด:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) ตัดสินใจว่าทรัพยากรควรเชื่อมโยงหรือฝังไว้
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) คืนค่า URL ที่จะถูกเขียนลงใน HTML ที่สร้างหรือทรัพยากรที่เชื่อมโยงอื่น
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) เขียนข้อมูลทรัพยากรที่เชื่อมโยงไปยังดิสก์หรือเป้าหมายการจัดเก็บอื่น

เส้นทางของระบบไฟล์และ URL ของเบราว์เซอร์เป็นเรื่องที่แตกต่างกัน ตัวอย่างเช่น ตัวอย่างด้านล่างเขียนไฟล์ทรัพยากรไปที่ `html-output/assets` บนดิสก์ ในขณะที่ HTML มี URL เชิงสัมพันธ์เช่น `assets/resource-1.svg` เบราว์เซอร์จะตีความ URL เหล่านั้นโดยสัมพันธ์กับไฟล์ที่มีลิงก์ ดังนั้นลิงก์จาก `presentation.html` ไปยังไฟล์ SVG จะใช้ `assets/resource-1.svg` ในขณะที่ลิงก์จากไฟล์ SVG นั้นไปยังรูปภาพที่บันทึกในโฟลเดอร์ `assets` เดียวกันจะใช้ `resource-4.jpg`

## **ส่งออก HTML พร้อมทรัพยากรที่เชื่อมโยง**

ตัวอย่าง C++ ด้านล่างสร้างไดเรกทอรีผลลัพธ์, บันทึกไฟล์ HTML ที่นั่น, และเก็บทรัพยากรที่เชื่อมโยงในโฟลเดอร์ย่อย `assets` ตัวควบคุมจะเชื่อมโยงรูปภาพ, ฟอนต์, เสียง, วิดีโอ, และทรัพยากร CSS ที่ Aspose.Slides ให้หรือสรุปนามสกุลไฟล์ที่ปลอดภัยได้ ทรัพยากรที่ไม่รู้จักจะยังคงถูกฝังไว้

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

หลังจากการส่งออก ไฟลเดอร์ผลลัพธ์จะมีโครงสร้างดังนี้:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

ไฟล์จริงที่ได้จะขึ้นกับเนื้อหาการนำเสนอและตัวเลือกการส่งออก ตัวอย่างเช่น ภาพเรสเตอร์มักจะถูกส่งออกเป็น JPEG หรือ PNG Aspose.Slides อาจเลือกโค้ดเอ็นโค้ดภาพที่ต่างจากที่ใช้ในไฟล์แหล่งเมื่อทำให้ไฟล์เล็กลงหรือเหมาะสมกว่า รูปภาพที่มีความโปร่งใสจะถูกส่งออกเป็น PNG

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL เชิงสัมพันธ์: `assets/` หากเปิด `presentation.html` จาก `html-output/presentation.html` เบราว์เซอร์จะโหลด `html-output/assets/resource-1.svg`

เมื่อทรัพยากรที่เชื่อมโยงหนึ่งอ้างถึงอีกทรัพยากรที่เชื่อมโยง ตัวอย่างใช้พารามิเตอร์ `referrer` ใน [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) และคืนค่าเฉพาะชื่อไฟล์ ตัวอย่างเช่น หาก `resource-1.svg` และ `resource-4.jpg` อยู่ในโฟลเดอร์ `assets` ไฟล์ SVG ควรอ้างถึง `resource-4.jpg` ไม่ใช่ `assets/resource-4.jpg`

ใช้คำนำหน้า URL ที่ต่างออกไปเมื่อไฟล์ถูกปรับใช้ในที่อื่น:

- ใช้ `assets/` เมื่อไดเรกทอรีสินทรัพย์อยู่ใกล้กับไฟล์ HTML.
- ใช้ `../assets/` เมื่อไดเรกทอรีสินทรัพย์อยู่หนึ่งระดับเหนือไฟล์ HTML.
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์ถูกอัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สเตติก.

URL ที่ [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) คืนค่าต้องตรงกับตำแหน่งสุดท้ายที่ไฟล์ที่ [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) เขียนไป ในแอปพลิเคชันเซิร์ฟเวอร์ ให้ใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าเก็บวัตถุที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น

## **เมื่อควรฝังแทนการเชื่อมโยง**

HTML ที่ฝัง Base64 ยังมีประโยชน์เมื่อผลลัพธ์ต้องเป็นไฟล์เดียว เช่น แนบในอีเมล, ตัวอย่างออฟไลน์, หรือเอกสารที่ต้องย้ายโดยไม่มีโฟลเดอร์สินทรัพย์สนับสนุน ทรัพยากรที่เชื่อมโยงเหมาะสมกว่าเมื่อ HTML จะถูกให้บริการโดยเว็บแอปพลิเคชัน, เก็บใน CMS, ปรับโดย pipeline การสร้าง, หรือแคชโดยเบราว์เซอร์แยกจาก HTML

## **คำถามที่พบบ่อย**

**ฉันสามารถทำให้เป็นไฟล์ภายนอกได้เฉพาะรูปภาพและให้ทรัพยากรอื่นฝังอยู่ได้หรือไม่?**

ได้. ใน [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) ให้คืนค่า `LinkEmbedDecision::Link` เฉพาะประเภทเนื้อหาที่คุณต้องการบันทึกเป็นไฟล์แยก, แล้วคืนค่า `LinkEmbedDecision::Embed` สำหรับส่วนอื่นทั้งหมด

**ทำไมนามสกุลของภาพที่ส่งออกถึงแตกต่างจากการนำเสนอแหล่ง?**

Aspose.Slides อาจทำการเข้ารหัสใหม่ของภาพเรสเตอร์ระหว่างการส่งออก HTML เพื่อปรับขนาดหรือความเข้ากันได้กับเบราว์เซอร์ ตัวอย่างเช่น ภาพจากไฟล์แหล่งอาจถูกเขียนเป็น JPEG หรือ PNG ขึ้นกับผลลัพธ์ที่เรนเดอร์

**URL เชิงสัมพันธ์ทำงานได้หลังจากย้ายไฟล์ HTML ไหม?**

URL เชิงสัมพันธ์ทำงานได้เฉพาะเมื่อโครงสร้างโฟลเดอร์เชิงสัมพันธ์เดียวกันยังคงอยู่ หาก HTML อ้างอิง `assets/resource-1.png` โฟลเดอร์ `assets` ต้องอยู่ข้างเคียงไฟล์ HTML เว้นแต่คุณจะสร้างคำนำหน้า URL ที่ต่างออกไป

**แอปพลิเคชันเซิร์ฟเวอร์ควรใช้โฟลเดอร์ผลลัพธ์เดียวกันซ้ำหรือไม่?**

ไม่. ให้ใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าเก็บที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง วิธีนี้จะหลีกเลี่ยงการชนชื่อไฟล์และป้องกันไม่ให้การส่งออกหนึ่งเขียนทับทรัพยากรที่สร้างโดยการส่งออกอื่น  