---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 60
url: /hi/python-net/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- ऑपरेटिंग सिस्टम
- स्थापना
- निर्भरताएँ
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET की सिस्टम आवश्यकताओं को जानें। Windows, Linux और macOS पर PowerPoint और OpenDocument समर्थन सुनिश्चित करें।"
---
## **परिचय**

Aspose.Slides for Python via .NET को किसी भी थर्ड-पार्टी उत्पाद, जैसे Microsoft PowerPoint, को स्थापित करने की आवश्यकता नहीं होती है। Aspose.Slides विभिन्न स्वरूपों में दस्तावेज़ बनाने, संशोधित करने, बदलने और रेंडर करने के लिए एक इंजन है, जिसमें Microsoft PowerPoint प्रस्तुति स्वरूप भी शामिल हैं।

## **समर्थित ऑपरेटिंग सिस्टम**

Aspose.Slides for Python Windows (32-bit और 64-bit), macOS, और 64-bit Linux को समर्थन देता है उन प्रणालियों पर जहाँ Python 3.5 या बाद का संस्करण स्थापित है।

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">ऑपरेटिंग सिस्टम</td>
        <td style="font-weight: bold; width:400px">संस्करण</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>और अन्य</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **लिनक्स और macOS प्लेटफ़ॉर्म के लिए सिस्टम आवश्यकताएँ**

- GCC 6 रUNTIME लाइब्रेरीज़ (या बाद की)।
- [libgdiplus](https://github.com/mono/libgdiplus), GDI+ API का एक ओपन-सोर्स कार्यान्वयन है।
- .NET Core Runtime की निर्भरताएँ। .NET Core Runtime को स्वयं स्थापित करना आवश्यक नहीं है।
- Python 3.5–3.7 के लिए: Python का `pymalloc` बिल्ड आवश्यक है। `--with-pymalloc` बिल्ड विकल्प डिफ़ॉल्ट रूप से सक्षम होता है। आम तौर पर, Python का `pymalloc` बिल्ड फाइलनाम में `m` उपसर्ग के साथ दर्शाया जाता है।
- `libpython` साझा लाइब्रेरी। `--enable-shared` Python बिल्ड विकल्प डिफ़ॉल्ट रूप से अक्षम है, और कुछ Python वितरणों में `libpython` साझा लाइब्रेरी शामिल नहीं होती। कुछ Linux प्लेटफ़ॉर्म पर, आप पैकेज मैनेजर (उदाहरण के लिए, `sudo apt-get install libpython3.7`) का उपयोग करके `libpython` साझा लाइब्रेरी स्थापित कर सकते हैं। एक सामान्य समस्या यह है कि `libpython` लाइब्रेरी गैर-मानक स्थान पर स्थापित होती है। आप इसे Python बिल्ड विकल्पों के माध्यम से वैकल्पिक लाइब्रेरी पाथ सेट करके, या सिस्टम की मानक साझा लाइब्रेरी स्थान में `libpython` लाइब्रेरी फ़ाइल का प्रतीक लिंक बनाकर हल कर सकते हैं। आम तौर पर, Python 3.5–3.7 के लिए `libpython` साझा लाइब्रेरी फ़ाइलनाम `libpythonX.Ym.so.1.0` होता है या Python 3.8 या बाद के लिए `libpythonX.Y.so.1.0` (उदाहरण के लिए, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`)।

## **FAQ**

**क्या मुझे रूपांतरण और रेंडरिंग के लिए Microsoft PowerPoint स्थापित करना आवश्यक है?**

नहीं, PowerPoint आवश्यक नहीं है; Aspose.Slides एक स्वतंत्र इंजन है जो प्रस्तुतियों को [बनाने](/slides/hi/python-net/create-presentation/), संशोधित करने, [बदलने](/slides/hi/python-net/convert-presentation/), और [रेंडरिंग](/slides/hi/python-net/convert-powerpoint-to-png/) करने में उपयोग किया जाता है।

**क्या मशीन पर कोई विशिष्ट .NET संस्करण (Core/5+/6+) आवश्यक है?**

.NET Runtime को स्वयं स्थापित करना आवश्यक नहीं है, लेकिन इसकी निर्भरताएँ Linux/macOS पर मौजूद होनी चाहिए। इसका अर्थ है कि सिस्टम में उन पैकेजों का होना चाहिए जो सामान्यतः .NET निर्भरताओं के रूप में स्थापित होते हैं, बिना पूरी Runtime को स्थापित किए।

**सही रेंडरिंग के लिए कौन से फ़ॉन्ट आवश्यक हैं?**

व्यावहारिक रूप से, प्रस्तुति में उपयोग किए गए फ़ॉन्ट या उचित [प्रतिस्थापित फ़ॉन्ट](/slides/hi/python-net/font-substitution/) उपलब्ध होने चाहिए। Linux/macOS पर निरंतर रेंडरिंग सुनिश्चित करने के लिए सामान्य फ़ॉन्ट पैकेज स्थापित करना अनुशंसित है।

**Linux पर कस्टम फ़ॉन्ट फॉलबैक या लापता टेक्स्ट के रूप में क्यों रेंडर होता है?**

यदि फ़ॉन्ट फ़ाइल में असंगत या भ्रष्ट नाम-टेबल प्रविष्टियाँ होती हैं, तो Linux फ़ॉन्ट‑मैचिंग स्टैक (FreeType/fontconfig) एक अमान्य रिकॉर्ड चुन सकता है, जिससे फ़ॉन्ट अपरिचित रह जाता है। सुधारित नाम‑टेबल रिकॉर्ड वाले फ़ॉन्ट संस्करण का उपयोग करने या एक सुसंगत प्रतिस्थापन स्थापित करने से समस्या हल हो जाती है।