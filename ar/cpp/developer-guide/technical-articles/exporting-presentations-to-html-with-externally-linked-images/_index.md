---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 50
url: /cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

تصف هذه المقالة تقنية متقدمة تتيح التحكم في الموارد التي يتم تضمينها في ملف HTML الناتج وأيها يتم حفظه خارجيًا ويتم الإشارة إليه من ملف HTML.

{{% /alert %}} 
## **الخلفية**
السلوك الافتراضي لتصدير HTML هو تضمين أي مورد داخل ملف HTML. تؤدي هذه الطريقة إلى ملف HTML واحد سهل العرض والتوزيع. جميع الموارد الضرورية مشفرة باستخدام base64 داخل الملف. ولكن لهذه الطريقة عيبان:

- حجم الإخراج أكبر بشكل ملحوظ بسبب التشفير باستخدام base64. من الصعب استبدال الصور الموجودة في الملف.

في هذه المقالة سنرى كيف يمكننا تغيير السلوك الافتراضي باستخدام **Aspose.Slides لـ C++** لربط الصور خارجيًا بدلاً من تضمينها في ملف HTML. سنستخدم واجهة [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) التي تحتوي على ثلاث طرق للتحكم في عملية تضمين الموارد وحفظها. يمكننا تمرير هذه الواجهة إلى منشئ [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) عند إعداد التصدير.

فيما يلي الكود الكامل لفئة **LinkController** التي تنفذ واجهة [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). كما ذُكر سابقًا، يجب على **LinkController** تنفيذ واجهة [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). تحدد هذه الواجهة ثلاث طرق:

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** يتم استدعاؤها عندما يواجه المصدر موردًا ويحتاج إلى اتخاذ قرار بشأن كيفية تخزينه. أهم المعلمات هي 'id' - المعرف الفريد للمورد لعملية التصدير بالكامل و 'contentType' - تحتوي على نوع MIME للمورد. إذا قررنا ربط المورد يجب أن نعيد LinkEmbedDecision::Link من هذه الطريقة. خلاف ذلك، يجب إعادة LinkEmbedDecision::Embed لتضمين المورد.
- **String GetUrl(int32_t id, int32_t referrer)**
  يتم استدعاؤها للحصول على رابط المورد بالصورة المستخدمة في الملف الناتج، مثل ```<img src="%method_result_here%">``` الوسم. يتم تحديد المورد بواسطة 'id'.
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  الطريقة النهائية في السلسلة، يتم استدعاؤها عندما يتعلق الأمر بتخزين المورد خارجيًا. لدينا معرف المورد ومحتويات المورد على شكل مصفوفة بايت. الأمر متروك لنا فيما نفعله مع بيانات المورد المقدمة.

``` cpp
/// <summary>
/// هذه الفئة مسؤولة عن اتخاذ القرارات بشأن الموارد المحفوظة خارجياً.
/// يجب أن تنفذ واجهة Aspose::Slides::Export::ILinkEmbedController.
/// </summary>
class LinkController : public ILinkEmbedController
{
public:
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>(); 
    }
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        // هنا نتخذ القرار بشأن تخزين الصور خارجيًا.
        // المعرف هو معرف فريد لكل كائن خلال عملية التصدير بالكامل.

        String template_;

        // تحتوي القاموس s_templates على أنواع المحتوى التي سنخزنها خارجيًا ونموذج اسم الملف المقابل.
        if (s_templates->TryGetValue(contentType, template_))
        {
            // تخزين هذه المورد في قائمة التصدير
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // سيتم تضمين جميع الموارد الأخرى، إن وجدت.
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // هنا نقوم بإنشاء سلسلة مرجعية للمورد لتشكيل الوسم: <img src="%result%">
        // نحتاج إلى التحقق من القاموس لتصفية الموارد غير الضرورية.
        // إلى جانب الفحص نستخرج نموذج اسم الملف المقابل.
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // نفترض أننا سنخزن ملفات المورد بالقرب من ملف HTML فقط.
            // سيبدو وسم الصورة كالتالي <img src="image-1.png"> مع المعرف المناسب للمورد والامتداد.
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // يجب إرجاع null بالنسبة للموارد التي تظل مضمنة
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // هنا نقوم فعلاً بحفظ ملفات المورد على القرص.
        // مرة أخرى، نتحقق من القاموس. إذا لم يتم العثور على المعرف هنا فهذا علامة على خطأ في طرق GetObjectStoringLocation أو GetUrl.
        if (m_externalImages->ContainsKey(id))
        {
            // الآن نستخدم اسم الملف المخزن في القاموس ونجمعه مع مسار حسب الحاجة.

            // إنشاء اسم الملف باستخدام النموذج المخزن والمعرف.
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // الجمع مع الدليل لمكان الحفظ
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"هناك شيء خاطئ");
        }
    }

private:
    String m_savePath;
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;
    static SharedPtr<Dictionary<String, String>> s_templates;

    static struct __StaticConstructor__
    {
        __StaticConstructor__()
        {
            s_templates->Add(u"image/jpeg", u"image-{0}.jpg");
            s_templates->Add(u"image/png", u"image-{0}.png");
        }
    } s_constructor__;
};
```

بعد كتابة فئة **LinkController**، سنستخدمها الآن مع فئة [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) لتصدير العرض التقديمي إلى HTML مع صور مرتبطة خارجيًا باستخدام الشيفرة التالية.

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// هذه السطر مطلوب لإزالة عرض عنوان الشريحة في HTML.
// قم بالتعليق عليه إذا كنت تفضل عرض عنوان الشريحة.
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

نمرر **SlideImageFormat::Svg** إلى طريقة **set_SlideImageFormat** مما يعني أن ملف HTML الناتج سيحتوي على بيانات SVG داخل لرسم محتويات العرض التقديمي.

أما بالنسبة لأنواع المحتوى، فهي تعتمد على بيانات الصورة الفعلية الموجودة في العرض التقديمي. إذا كان هناك صور نقطية في العرض التقديمي، فيجب أن يكون كود الفئة جاهزًا لمعالجة كل من أنواع المحتوى 'image/jpeg' و'image/png'. النوع الفعلي للمحتوى لصور النقطية المصدّرة قد لا يتطابق مع نوع المحتوى للصور المخزنة في العرض التقديمي. تقوم خوارزميات Aspose.Slides لـ C++ الداخلية بأداء تحسين الحجم وتستخدم إما ترميز JPG أو PNG أيهما ينتج حجم بيانات أصغر. يتم دائمًا ترميز الصور التي تحتوي على قناة ألفا (الشفافية) لتكون PNG.