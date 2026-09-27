---
title: स्थापना
type: docs
weight: 70
url: /hi/cpp/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides स्थापना
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Visual Studio में Windows पर NuGet से C++ के लिए Aspose.Slides स्थापित करें, या Linux पर CMake के साथ ZIP पैकेज से, और पहली प्रोग्राम से स्थापना की जाँच करें।"
---
## **अवलोकन**

Aspose.Slides for C++ दो रूपों में वितरित किया जाता है:

| रूप | उपयोग हेतु | कहां से प्राप्त करें |
|---|---|---|
| NuGet पैकेज: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64-bit) और [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32-bit) | Windows पर Visual Studio C++ प्रोजेक्ट्स | NuGet |
| Windows, Linux और macOS के लिये ZIP पैकेज | एन्यूजेट के बिना बिल्ड, जैसे CMake प्रोजेक्ट्स | [डाउनलोड पेज](https://releases.aspose.com/slides/hi/cpp/) |

यह लेख दिखाता है कि Windows पर Visual Studio में NuGet पैकेज कैसे स्थापित करें और Linux पर CMake के साथ ZIP पैकेज का उपयोग कैसे करें। दोनों मार्ग समान जांच के साथ समाप्त होते हैं: [Create Presentations](/slides/hi/cpp/create-presentation/) में पहला उदाहरण बनाकर चलाएँ।

## **Windows**

Windows पर, Visual Studio C++ प्रोजेक्ट में NuGet पैकेज जोड़ें। पैकेज अपनी निर्भरता CodePorting.Translator.Cs2Cpp.Framework को भी स्थापित करता है, और आपके प्रोग्राम को आवश्यक DLLs को बिल्ड आउटपुट फोल्डर में कॉपी करता है।

उस प्लेटफ़ॉर्म के आधार पर पैकेज चुनें जिसके लिए आप बिल्ड कर रहे हैं: x64 के लिये **Aspose.Slides.Cpp**, और Win32 (x86) के लिये **Aspose.Slides.Cpp.x86**। Aspose.Slides.Cpp पैकेज Win32 बिल्ड पर लागू नहीं होता, इसलिए कंपाइलर वहां इसके हेडर नहीं ढूँढ पाता।

एक Windows ZIP पैकेज भी [डाउनलोड पेज](https://releases.aspose.com/slides/hi/cpp/) से उपलब्ध है।

### **विधि 1: NuGet पैकेज प्रबंधक से Aspose.Slides स्थापित या अपडेट करें**

1. Microsoft Visual Studio खोलें।
2. एक C++ **Console App** प्रोजेक्ट बनायें, या मौजूदा प्रोजेक्ट खोलें।
3. **Solution Explorer** में, प्रोजेक्ट पर राइट-क्लिक करें और **Manage NuGet Packages** चुनें (या **Project** > **Manage NuGet Packages** पर जाएँ)।
4. **Browse** के तहत, *Aspose.Slides.Cpp* खोजें।
![NuGet पैकेज मैनेजर में Aspose.Slides.Cpp की खोज](installation_1.png)
5. **Aspose.Slides.Cpp** पर क्लिक करें (या 32‑bit बिल्ड के लिये **Aspose.Slides.Cpp.x86**) और फिर **Install** पर क्लिक करें।  
   * यदि आपने पहले ही Aspose.Slides स्थापित कर लिया है और इसे अपडेट करना चाहते हैं, तो **Update** पर क्लिक करें।

पैकेज डाउनलोड हो जाता है और आपके प्रोजेक्ट में संदर्भित किया जाता है।

### **विधि 2: पैकेज मैनेजर कंसोल के माध्यम से Aspose.Slides स्थापित या अपडेट करें**

1. Microsoft Visual Studio खोलें।
2. एक C++ **Console App** प्रोजेक्ट बनायें, या मौजूदा प्रोजेक्ट खोलें।
3. **Tools** > **NuGet Package Manager** > **Package Manager Console** पर जाएँ.
![पैकेज मैनेजर कंसोल खोलना](installation_2.png)
4. इस कमांड को चलाएँ:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   32‑बिट (Win32) बिल्ड के लिये, इसके बजाय x86 पैकेज स्थापित करें:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![Install-Package कमांड चलाना](installation_3.png)

जब स्थापना पूरी हो जाती है, पुष्टि संदेश दिखाई देते हैं। पैकेज [Aspose EULA](https://about.aspose.com/legal/eula) के तहत वितरित किया जाता है।
![स्थापना पुष्टि संदेश](installation_4.png)

पैकेज को अपडेट करने के लिये, पैकेज मैनेजर कंसोल में `Update-Package Aspose.Slides.Cpp` (या `Update-Package Aspose.Slides.Cpp.x86`) चलाएँ।

### **इंस्टॉलेशन की जाँच**

1. प्रोजेक्ट की मुख्य *.cpp* फ़ाइल (जिसमें `main` होता है) की सामग्री को [Create Presentations](/slides/hi/cpp/create-presentation/) में पहला उदाहरण रखकर बदलें।
2. टूलबार में, **x64** प्लेटफ़ॉर्म चुनें, या यदि आपने Aspose.Slides.Cpp.x86 स्थापित किया है तो **x86** चुनें।
3. **Ctrl+F5** दबाएँ ताकि प्रोग्राम बिल्ड और चलाया जा सके।

प्रोग्राम *hello.pptx* को प्रोजेक्ट फ़ोल्डर में सहेजता है, जो Visual Studio द्वारा प्रोग्राम चलाते समय डिफ़ॉल्ट कार्य निर्देशिका होती है।

## **Linux**

Linux पर, CMake के साथ Linux ZIP पैकेज का उपयोग करें। इसमें Aspose.Slides लाइब्रेरी, उसकी निर्भरता CodePorting.Translator.Cs2Cpp.Framework, और प्रत्येक के लिये एक CMake कॉन्फ़िगरेशन फ़ाइल शामिल है। लाइब्रेरियों को x86_64 Linux पर glibc 2.23 या उससे बाद के संस्करण के साथ बनाया गया है।

1. एक C++ कंपाइलर, make, CMake, unzip, और fontconfig लाइब्रेरी स्थापित करें, जिसपर Aspose.Slides लाइब्रेरी निर्भर करती है। Debian और Ubuntu पर:
   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```
2. एक प्रोजेक्ट फ़ोल्डर बनायें और उसमें जाएँ:
   ```bash
   mkdir hello-slides
   cd hello-slides
   ```
3. Linux ZIP (**Aspose.Slides for C++ Linux**) को [डाउनलोड पेज](https://releases.aspose.com/slides/hi/cpp/) से प्रोजेक्ट फ़ोल्डर में डाउनलोड करें, और इसे *aspose-slides-cpp* उपफ़ोल्डर में अनज़िप करें:
   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```
4. प्रोजेक्ट फ़ोल्डर में *CMakeLists.txt* नाम की फ़ाइल इस सामग्री के साथ बनायें:
   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   दो `find_package` कॉल्स अनज़िप किए पैकेज से CMake कॉन्फ़िगरेशन फ़ाइलों को लोड करते हैं। फ्रेमवर्क पहले पाया जाता है क्योंकि Aspose.Slides उसी पर निर्भर करता है। `Aspose.Slides.Cpp` टार्गेट को लिंक करने से इनक्लूड फ़ोल्डर और दोनों लाइब्रेरीज़ बिल्ड में जुड़ते हैं।

5. पहले उदाहरण को [Create Presentations](/slides/hi/cpp/create-presentation/) से *main.cpp* के रूप में प्रोजेक्ट फ़ोल्डर में सहेजें।
6. प्रोग्राम बनायें और चलायें:
   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

प्रोग्राम *hello.pptx* को वर्तमान फ़ोल्डर में सहेजता है। CMake लाइब्रेरीज़ का स्थान प्रोग्राम में रिकॉर्ड करता है, इसलिए जब तक *aspose-slides-cpp* फ़ोल्डर जगह पर है, आपको `LD_LIBRARY_PATH` सेट करने की आवश्यकता नहीं है।

आपकी प्रस्तुतियों में उपयोग किए गए फ़ॉन्ट्स, या उनके उपयुक्त विकल्प, सिस्टम पर स्थापित होने चाहिए ताकि जब आप स्लाइड्स को PDF या इमेज में बदलें तो पाठ सही ढंग से रेंडर हो।

## **FAQ**

**क्या कोई मुफ्त संस्करण या ट्रायल प्रतिबंध है?**

हाँ। बिना लाइसेंस के, Aspose.Slides मूल्यांकन मोड में चलती है: यह प्रत्येक सहेजी गई स्लाइड में एक मूल्यांकन वॉटरमार्क जोड़ती है और प्रस्तुतियों से पढ़े गए पाठ को छोटा कर देती है। इन प्रतिबंधों को हटाने के लिये, वैध [license](/slides/hi/cpp/licensing/) लागू करें।

**कम्पाइलर रिपोर्ट करता है कि वह *DOM/Presentation.h* खोल नहीं सकता, ऐसा क्यों?**

स्थापित पैकेज आपके बिल्ड प्लेटफ़ॉर्म से मेल नहीं खाता। Aspose.Slides.Cpp केवल x64 बिल्ड के लिये लागू होता है, और Aspose.Slides.Cpp.x86 केवल Win32 बिल्ड के लिये। Visual Studio में मिलते‑जुलते प्लेटफ़ॉर्म को चुनें, या अन्य पैकेज स्थापित करें।